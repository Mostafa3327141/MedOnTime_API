using Core.Models.MedicationNameSpace;
using Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedOnTime_API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class MedicationAPIController : ControllerBase
    {
        private IMedicationServices _medicationServices;
        public MedicationAPIController(IMedicationServices medcationServices)
        {
            _medicationServices = medcationServices;
        }

        [HttpGet]
        public IActionResult GetMedication(string key = "")
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            return Ok(_medicationServices.GetMedications());
        }

        [HttpGet("{id}", Name = "GetMedication")]
        public IActionResult GetMedication(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(_medicationServices.GetMedication(id));
        }

        [HttpPost]
        public IActionResult AddMedication(Medication medication)
        {
            _medicationServices.AddMedication(medication);
            return CreatedAtRoute("GetMedication", new { id = medication.Id }, medication);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedication(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }

            _medicationServices.DeleteMedication(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateMedication(Medication medicationToUpdate)
        {
            return Ok(_medicationServices.UpdateMedication(medicationToUpdate));
        }
    }
}
