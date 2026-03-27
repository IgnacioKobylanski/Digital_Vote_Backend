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
        public Candidate Candidate { get; set; } = null!;

        [Required]
        public int PartyId { get; set; }
        public Party Party { get; set; } = null!;

        public DateTime VotedAt { get; set; } = DateTime.Now;
    }
}