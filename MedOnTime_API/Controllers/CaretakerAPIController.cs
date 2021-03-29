using MedOnTime.Core.Models.CaretakerNameSpace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedOnTime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaretakerAPIController : ControllerBase
    {
        private ICaretakerServices _caretakerServices;
        public CaretakerAPIController(ICaretakerServices caretakerServices)
        {
            _caretakerServices = caretakerServices;
        }

        [HttpGet]
        public IActionResult GetCaretaker()
        {
            return Ok(_caretakerServices.GetCaretakers());
        }

        [HttpGet("{id}", Name = "GetCaretaker")]
        public IActionResult GetCaretaker(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                return Ok(_caretakerServices.GetCaretaker(id));
            }
        }

        [HttpPost]
        public IActionResult AddCaretaker(Caretaker caretaker)
        {
            _caretakerServices.AddCaretaker(caretaker);
            return CreatedAtRoute("GetCaretaker", new { id = caretaker.Id }, caretaker);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCaretaker(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                _caretakerServices.DeleteCaretaker(id);
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdateCaretaker(Caretaker caretakerToUpdate)
        {
            return Ok(_caretakerServices.UpdateCaretaker(caretakerToUpdate));
        }
    }
}
