using Microsoft.AspNetCore.Mvc;

namespace MarvelRivalsApi.Controllers
{

    [ApiController]
    [Route("api/overwolf")]
    public class OverwolfEventsController : ControllerBase // Fix: Inherit from ControllerBase to use Ok() and other helper methods
    {
        private static readonly List<object> _events = new();

        [HttpPost("events")]
        public IActionResult ReceiveEvent([FromBody] object evt)
        {
            _events.Add(evt);
            Console.WriteLine("Received event: " + evt);
            return Ok("event ok");
        }

        [HttpGet("events")]
        public IActionResult GetEvents()
        {
            return Ok(_events);
        }
    }
}
