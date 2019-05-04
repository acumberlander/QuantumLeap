using Microsoft.AspNetCore.Mvc;
using QuantumLeap.cs.Data;
using QuantumLeap.cs.Models;

namespace QuantumLeap.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaperController : ControllerBase
    {
        readonly LeapersRepository _leapersRepository;

        public LeaperController()
        {
            _leapersRepository = new LeapersRepository();
        }

        [HttpPost]
        public ActionResult AddLeaper(CreateLeaperRequest createRequest)
        {
            var newLeaper = _leapersRepository.AddLeaper(createRequest.Name);

            return Created($"api/leaper/{newLeaper.Id}", newLeaper);

        }

        [HttpGet]
        public ActionResult GetAllLeapers()
        {
            var leapers = _leapersRepository.GetAll();

            return Ok(leapers);
        }

    }
}