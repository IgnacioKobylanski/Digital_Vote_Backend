namespace DigitalVote.API.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool HasVoted { get; set; }
    }
}
