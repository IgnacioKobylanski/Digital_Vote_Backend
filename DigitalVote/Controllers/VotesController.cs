using DigitalVote.API.Data;
using DigitalVote.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalVote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostVote(string dni, int candidateId)
        {
            var voter = await _context.Voters.FirstOrDefaultAsync(v => v.Dni == dni);

            if (voter == null)
            {
                return NotFound("Identidad no verificada: El DNI ingresado no figura en el padrón.");
            }

            if (voter.HasVoted)
            {
                return BadRequest($"El ciudadano {voter.FullName} ya ha votado.");
            }

            var candidateExists = await _context.Candidates.AnyAsync(c => c.Id == candidateId);
            if (!candidateExists)
            {
                return NotFound("El candidato seleccionado no existe.");
            }

            try
            {
                var vote = new Vote
                {
                    VoterId = voter.Id,
                    CandidateId = candidateId,
                    VotedAt = DateTime.Now
                };

                voter.HasVoted = true;
                _context.Votes.Add(vote);

                await _context.SaveChangesAsync();

                return Ok($"Voto procesado con éxito. ¡Gracias por votar, {voter.FullName}!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el voto: {ex.Message}");
            }
        }
    }
}