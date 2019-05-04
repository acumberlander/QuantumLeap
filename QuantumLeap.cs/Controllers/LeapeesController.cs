using Microsoft.AspNetCore.Mvc;
using QuantumLeap.cs.Data;
using QuantumLeap.cs.Models;

namespace QuantumLeap.cs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LeapeesController : ControllerBase
    {
        readonly LeapeesRepository _leapeesRepository;

        public LeapeesController()
        {
            _leapeesRepository = new LeapeesRepository();
        }
        [HttpPost]
        public ActionResult AddLeapee(CreateLeapeeRequest createRequest)
        {
            var repository = new LeapeesRepository();

            var newLeapee = repository.AddLeapee(
                createRequest.Name,
                createRequest.Job);

            return Created($"/api/leapee/{newLeapee.Id}", newLeapee);
        }

        [HttpGet]
        public ActionResult GetAllLeapees()
        {
            var leapees = _leapeesRepository.GetAll();

            return Ok(leapees);
        }
    }
}