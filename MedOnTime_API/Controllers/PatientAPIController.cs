using Core.Models.PatientSpace;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedOnTime_API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        private IPatientServices _patientServices;
        public PatientAPIController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [HttpGet]
        public IActionResult GetPatients(string key = "", string? caretakerID = null)
        {
            if ("sH5O!2cdOqP1%".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(caretakerID))
            {
                return Ok(_patientServices.GetPatients());
            }
            
            return Ok(_patientServices.GetPatients(int.Parse(caretakerID)));

        }

        [HttpGet("{id}", Name = "GetPatient")]
        public IActionResult GetPatient(string key = "", string? id = null)
        {
            if ("sH5O!2cdOqP1%".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            
            return Ok(_patientServices.GetPatient(id));
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            _patientServices.AddPatient(patient);
            return CreatedAtRoute("GetPatient", new { id = patient.PatientID }, patient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(string key = "", string? id = null)
        {
            if ("sH5O!2cdOqP1%".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            
            _patientServices.DeletePatient(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdatePatient(Patient patientToUpdate)
        {
            return Ok(_patientServices.UpdatePatient(patientToUpdate));
        }
    }
}
