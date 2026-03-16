using System.ComponentModel.DataAnnotations;

namespace DigitalVote.API.Models
{
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public int VoterId { get; set; }

        [Required]
        public int CandidateId { get; set; }

        public DateTime VotedAt { get; set; } = DateTime.Now;
    }
}
