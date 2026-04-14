using DigitalVote.API.DTOs;

namespace DigitalVote.API.Services
{
    public interface IVoteService
    {
        Task<(bool Success, string Message)> RegisterVoteAsync(VoteRequestDto request);
    }
}