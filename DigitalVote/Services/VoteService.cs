using DigitalVote.API.Data;
using DigitalVote.API.Models;
using DigitalVote.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DigitalVote.API.Services
{
    public class VoteService : IVoteService
    {
        private readonly ApplicationDbContext _context;

        public VoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> RegisterVoteAsync(VoteRequestDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var voter = await _context.Voters.FirstOrDefaultAsync(v => v.Dni == request.Dni);
                if (voter == null) return (false, "Votante no encontrado.");
                if (voter.HasVoted) return (false, "El ciudadano ya emitió su voto.");

                var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == request.CandidateId);
                if (candidate == null) return (false, "Candidato inválido.");

                var vote = new Vote
                {
                    VoterId = voter.Id,
                    CandidateId = candidate.Id,
                    PartyId = candidate.PartyId,
                    VotedAt = DateTime.Now
                };

                _context.Votes.Add(vote);

                voter.HasVoted = true;
                voter.VoteDate = DateTime.Now;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return (true, $"Voto registrado para {voter.FullName}");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                var realError = ex.InnerException?.Message ?? ex.Message;
                return (false, $"Error de Base de Datos: {realError}");
            }
        }
    }
}