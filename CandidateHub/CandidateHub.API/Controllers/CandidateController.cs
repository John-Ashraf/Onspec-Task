using CandidateHub.Application.Abstracts;
using CandidateHub.Domain.Models.DTOS;
using CandidateHub.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto candidate)
        {
            var Candidate = new Candidate
            {
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Comment = candidate.Comment,
                LinkedInUrl = candidate.LinkedInUrl,
                GitHubUrl = candidate.GitHubUrl,
                PhoneNumber = candidate.PhoneNumber,
                PreferredCallTime = candidate.PreferredCallTime,
            };
            await _service.AddCandidateAsync(Candidate);
            return Ok(new { message = "Candidate saved successfully." });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById([FromRoute] int id)
        {
            var res = await _service.GetCandidateById(id);
            return Ok(res);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, [FromForm] CandidateCreateDto candidate)
        {
            var updatedCandidate = new Candidate
            {
                Id = id,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Comment = candidate.Comment,
                LinkedInUrl = candidate.LinkedInUrl,
                GitHubUrl = candidate.GitHubUrl,
                PhoneNumber = candidate.PhoneNumber,
                PreferredCallTime = candidate.PreferredCallTime,
            };
            await _service.UpdateCandidateAsync(updatedCandidate);
            return Ok(new { message = "Candidate updated" });
        }
        [HttpGet("ByEmail")]
        public async Task<IActionResult> GetCandidateByEmail([FromQuery] string email)
        {
            var res = await _service.GetCandidateByEmail(email);
            return res == null ? NotFound() : Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            var res = await _service.GetAllCandidatesAsync();
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            await _service.DeleteCandidate(id);
            return Ok(new { message = "Candidate deleted" });
        }
    }
}
