using MedOnTime.Core.Models.logSpace;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult GetLog(string LogId)
        {
            return Ok(_logServices.GetLog(LogId));
        }

        [HttpGet(Name = "GetPatientLogs")]
        public IActionResult GetPatientLogs(string patientID)
        {
            if (String.IsNullOrEmpty(patientID))
            {
                return Ok(_logServices.GetLogs());
            }
            else
            {
                return Ok(_logServices.GetPatientLogs(patientID));
            }
        }

        [HttpPost]
        public IActionResult AddLog(Log log)
        {
            _logServices.AddLog(log);
            return CreatedAtRoute("GetLog", new { LogId = log.Id }, log);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLog(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            else
            {
                _logServices.DeleteLog(id);
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateLog(Log logToUpdate)
        {
            return Ok(_logServices.UpdateLog(logToUpdate));
        }
    }
}
