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
        public IActionResult GetPatients(string caretakerID)
        {
            if (String.IsNullOrEmpty(caretakerID))
            {
                return Ok(_patientServices.GetPatients());
            }
            else
            {
                return Ok(_patientServices.GetPatients(int.Parse(caretakerID)));
            }
        }

        [HttpGet("{id}", Name = "GetPatient")]
        public IActionResult GetPatient(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                return Ok(_patientServices.GetPatient(id));
            }
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            _patientServices.AddPatient(patient);
            return CreatedAtRoute("GetPatient", new { id = patient.PatientID }, patient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                _patientServices.DeletePatient(id);
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdatePatient(Patient patientToUpdate)
        {
            return Ok(_patientServices.UpdatePatient(patientToUpdate));
        }
    }
}
