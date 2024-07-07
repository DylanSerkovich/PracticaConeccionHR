using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaConeccionHR.Model;
using PracticaConeccionHR.Repository;

namespace PracticaConeccionHR.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _jobsRepository.GetAllBranches();
                return Ok(employees);
            }
            catch (Exception exp)
            {
                return Ok(exp.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            try
            {
                var job = _jobsRepository.GetById(id);
                if (job == null)
                {
                    return NotFound();
                }
                return Ok(job);
            }
            catch (Exception exp)
            {
                return Ok(exp.Message);
            }

        }

        [HttpPost]
        public IActionResult AddJob([FromBody] Jobs job)
        {
            try
            {
                _jobsRepository.AddJob(job);
                return CreatedAtAction(nameof(GetById), new { id = job.JobId }, job);
            }
            catch (Exception exp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exp.Message);
            }
        }
    }
}
