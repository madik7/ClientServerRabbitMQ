using Client.Application.Handlers.Job;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Client.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobAsync(CreateJobDto createJobDto)
        {
            var id = await _mediator.Send(createJobDto);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllJobs()
        {
            await _mediator.Send(new StopJobDto());
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteJobById([FromRoute] StopJobDto stopJobDto)
        {
            await _mediator.Send(stopJobDto);
            return NoContent();
        }

    }
}
