using System.Text.Json.Serialization;

namespace DigitalVote.API.DTOs
{
    public class VoteRequestDto
    {
        [JsonPropertyName("dni")]
        public string Dni { get; set; } = string.Empty;

        [JsonPropertyName("candidateId")]
        public int CandidateId { get; set; }
    }
}