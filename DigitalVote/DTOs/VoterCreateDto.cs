namespace DigitalVote.API.DTOs
{
    public class VoterCreateDto
    {
        public string Dni { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}