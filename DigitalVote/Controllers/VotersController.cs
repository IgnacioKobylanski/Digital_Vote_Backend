using DigitalVote.API.Data;
using DigitalVote.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalVote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VotersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVoters()
        {
            return await _context.Voters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voter>> GetVoter(int id)
        {
            var voter = await _context.Voters.FindAsync(id);
            if (voter == null) return NotFound();
            return voter;
        }

        [HttpPost]
        public async Task<ActionResult<Voter>> PostVoter(Voter voter)
        {
            _context.Voters.Add(voter);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVoter), new { id = voter.Id }, voter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoter(int id, Voter voter)
        {
            if (id != voter.Id) return BadRequest();

            _context.Entry(voter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Voters.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoter(int id)
        {
            var voter = await _context.Voters.FindAsync(id);
            if (voter == null) return NotFound();

            _context.Voters.Remove(voter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}