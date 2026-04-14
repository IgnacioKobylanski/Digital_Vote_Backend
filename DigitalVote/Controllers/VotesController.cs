using DigitalVote.API.DTOs;
using DigitalVote.API.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class VotesController : ControllerBase
{
    private readonly IVoteService _voteService;

    public VotesController(IVoteService voteService)
    {
        _voteService = voteService;
    }

    [HttpPost]
    public async Task<IActionResult> PostVote([FromBody] VoteRequestDto request)
    {
        var result = await _voteService.RegisterVoteAsync(request);

        if (!result.Success)
            return BadRequest(new { message = result.Message });

        return Ok(new { message = result.Message });
    }
}