using Core.Models.logSpace;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedOnTime_API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class LogAPIController : Controller
    {
        private ILogServices _logServices;
        public LogAPIController(ILogServices logServices)
        {
            _logServices = logServices;
        }

        [HttpGet("{LogId}")]
        public IActionResult GetLog(string key = "", string? LogId = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            return Ok(_logServices.GetLog(LogId));
        }

        [HttpGet(Name = "GetPatientLogs")]
        public IActionResult GetPatientLogs(string key = "", string? patientID = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(patientID))
            {
                return Ok(_logServices.GetLogs());
            }
            
            return Ok(_logServices.GetPatientLogs(patientID));
        }

        [HttpPost]
        public IActionResult AddLog(Log log)
        {
            _logServices.AddLog(log);
            return CreatedAtRoute("GetLog", new { LogId = log.Id }, log);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLog(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }

            _logServices.DeleteLog(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateLog(Log logToUpdate)
        {
            return Ok(_logServices.UpdateLog(logToUpdate));
        }
    }
}
