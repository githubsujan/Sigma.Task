using MediatR;

using Microsoft.AspNetCore.Mvc;

using Sigma.Task.Application.Commands;
using Sigma.Task.Application.DTOs;
using Sigma.Task.Application.Queries;

namespace Sigma.Task.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ISender _sender;

        public CandidateController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetCandidates")]
        public async Task<IActionResult> GetCandidatesAsync()
        {
            var result = await _sender.Send(new GetCandidatesQuery());
            return Ok(result);
        }

        [HttpPost("SaveCandidate")]
        public async Task<IActionResult> SaveCandidate([FromBody] CandidateDTO candidateDTO)
        {
            var result = await _sender.Send(new SaveCandidateCommand(candidateDTO));
            return Ok(result);
        }
    }
}
