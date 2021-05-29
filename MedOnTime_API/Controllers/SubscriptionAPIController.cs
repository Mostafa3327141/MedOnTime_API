using Core.Models.SubscriptionSpace;
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
    public class SubscriptionAPIController : ControllerBase
    {
        private ISubscriptionServices _subscriptionServices;
        public SubscriptionAPIController(ISubscriptionServices subscriptionServices)
        {
            _subscriptionServices = subscriptionServices;
        }

        [HttpGet]
        public IActionResult GetSubscriptions(string key = "")
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            return Ok(_subscriptionServices.GetSubscriptions());
        }

        [HttpGet("{id}", Name = "GetSubscriptions")]
        public IActionResult GetSubscription(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            
            return Ok(_subscriptionServices.GetSubscription(id));
        }

        [HttpPost]
        public IActionResult AddSubscription(Subscription subscription)
        {
            _subscriptionServices.AddSubscription(subscription);
            return CreatedAtRoute("GetSubscription", new { id = subscription.Id }, subscription);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscription(string key = "", string? id = null)
        {
            if (!"sH5O!2cdOqP1^".Equals(key))
            {
                return BadRequest("Invalid API Key.");
            }
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Value must be passed in the request body.");
            }
            
            _subscriptionServices.DeleteSubscription(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateSubscription(Subscription subscriptionToUpdate)
        {
            return Ok(_subscriptionServices.UpdateSubscription(subscriptionToUpdate));
        }
    }
}
