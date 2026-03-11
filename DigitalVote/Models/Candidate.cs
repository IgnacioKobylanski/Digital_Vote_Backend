namespace DigitalVote.API.Models
{
    public class Candidate
    {   public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Party { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
