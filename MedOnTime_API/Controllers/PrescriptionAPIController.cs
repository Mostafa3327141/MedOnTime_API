using MedOnTime.Core.Models.PrescriptionSpace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedOnTime_API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PrescriptionAPIController : ControllerBase
    {
        private IPrescriptionServices _prescriptionServices;
        public PrescriptionAPIController(IPrescriptionServices prescriptionServices)
        {
            _prescriptionServices = prescriptionServices;
        }

        [HttpGet]
        public IActionResult GetPrescription()
        {
            return Ok(_prescriptionServices.GetPrescriptions());
        }

        [HttpGet("{id}", Name = "GetPrescription")]
        public IActionResult GetPrescription(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                return Ok(_prescriptionServices.GetPrescription(id));
            }
        }

        [HttpPost]
        public IActionResult AddPrescription(Prescription prescription)
        {
            _prescriptionServices.AddPrescription(prescription);
            return CreatedAtRoute("GetPrescription", new { id = prescription.Id }, prescription);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrescription(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                _prescriptionServices.DeletePrescription(id);
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdatePrescription(Prescription prescriptionToUpdate)
        {
            return Ok(_prescriptionServices.UpdatePrescription(prescriptionToUpdate));
        }
    }
}
