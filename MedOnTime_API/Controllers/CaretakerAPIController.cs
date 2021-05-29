using Core.Models.CaretakerNameSpace;
using Microsoft.AspNetCore.Mvc;
using System;
namespace MedOnTime_API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class CaretakerAPIController : ControllerBase
    {
        private ICaretakerServices _caretakerServices;
        public CaretakerAPIController(ICaretakerServices caretakerServices)
        {
            _caretakerServices = caretakerServices;
        }

        [HttpGet]
        public IActionResult GetCaretaker(string key = "")
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            return Ok(_caretakerServices.GetCaretakers());
        }

        [HttpGet("{id}", Name = "GetCaretaker")]
        public IActionResult GetCaretaker(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }

            return Ok(_caretakerServices.GetCaretaker(id));
        }

        [HttpPost]
        public IActionResult AddCaretaker(Caretaker caretaker)
        {
            _caretakerServices.AddCaretaker(caretaker);
            return CreatedAtRoute("GetCaretaker", new { id = caretaker.Id }, caretaker);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCaretaker(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }

            _caretakerServices.DeleteCaretaker(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCaretaker(Caretaker caretakerToUpdate)
        {
            return Ok(_caretakerServices.UpdateCaretaker(caretakerToUpdate));
        }
    }
}
