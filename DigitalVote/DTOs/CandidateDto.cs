namespace DigitalVote.API.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CandidateImg { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public DigitalVote.API.Models.Position? Position { get; set; }
        public int PartyId { get; set; }
        public DigitalVote.API.Models.Party? Party { get; set; }
    }
}