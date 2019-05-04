using Microsoft.AspNetCore.Mvc;
using QuantumLeap.cs.Data;
using QuantumLeap.cs.Models;

namespace QuantumLeap.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddEvent(CreateEventRequest createRequest)
        {
            var repository = new EventsRepository();

            var newEvent = repository.AddEvent(
                createRequest.Name,
                createRequest.Date);

            return Created($"/api/event/{newEvent.Id}", newEvent);
        }
    }
}