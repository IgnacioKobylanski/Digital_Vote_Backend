namespace DigitalVote.API.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{LastName}, {FirstName}";

        public bool HasVoted { get; set; } = false;
        public DateTime? VoteDate { get; set; }
    }
}