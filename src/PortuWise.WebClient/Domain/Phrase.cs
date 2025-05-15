namespace PortuWise.WebClient.Domain
{
    public class Phrase
    {
        public Guid Id { get; set; }
        public Guid WordId { get; set; }
        public string Pt { get;set; } = string.Empty;
        public string PtTranscription{ get;set; } = string.Empty;
        public string Eng { get;set; } = string.Empty;
        public string EngTranscription{ get;set; } = string.Empty;
        public string Rus { get;set; } = string.Empty;
    }
}
