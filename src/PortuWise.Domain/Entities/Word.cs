using PortuWise.Domain.Entities;

namespace PortuWise.WebApi.Domain.Entities
{
    public class Word : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Pt { get;set; } = string.Empty;
        public string PtTranscription{ get;set; } = string.Empty;
        public string Eng { get;set; } = string.Empty;
        public string EngTranscription{ get;set; } = string.Empty;
        public string Rus { get;set; } = string.Empty;

        public List<Phrase> Phrases { get; set; } = new();
    }
}
