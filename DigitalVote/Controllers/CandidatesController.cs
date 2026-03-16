using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalVote.API.Data;
using DigitalVote.API.Models;
using DigitalVote.API.DTOs;

namespace DigitalVote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id) return BadRequest();
            _context.Entry(candidate).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Candidates.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null) return NotFound();
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("results")]
        public async Task<ActionResult<IEnumerable<ElectionResultDto>>> GetResults()
        {
            var results = await _context.Candidates
                .Select(c => new ElectionResultDto
                {
                    CandidateName = c.Name,
                    TotalVotes = _context.Votes.Count(v => v.CandidateId == c.Id)
                })
                .OrderByDescending(r => r.TotalVotes)
                .ToListAsync();

            return Ok(results);
        }
    }
}