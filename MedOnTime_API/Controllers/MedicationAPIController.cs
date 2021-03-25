using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedOnTime.Core;
using MedOnTime_WebApp;

namespace MedOnTime_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationAPIController : ControllerBase
    {
        private IMedicationServices _medicationServices;
        public MedicationAPIController(IMedicationServices medcationServices)
        {
            _medicationServices = medcationServices;
        }

        [HttpGet]
        public IActionResult GetMedication()
        {
            return Ok(_medicationServices.GetMedications());
        }

        [HttpGet("{id}", Name = "GetMedication")]
        public IActionResult GetMedication(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                return Ok(_medicationServices.GetMedication(id));
            }
        }

        [HttpPost]
        public IActionResult AddMedication(Medication medication)
        {
            _medicationServices.AddMedication(medication);
            return CreatedAtRoute("GetBook", new { id = medication.Id }, medication);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedication(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                _medicationServices.DeleteMedication(id);
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdateMedication(Medication medicationToUpdate)
        {
            return Ok(_medicationServices.UpdateMedication(medicationToUpdate));
        }
    }
}
