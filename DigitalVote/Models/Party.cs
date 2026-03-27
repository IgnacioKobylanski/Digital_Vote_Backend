namespace DigitalVote.API.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}