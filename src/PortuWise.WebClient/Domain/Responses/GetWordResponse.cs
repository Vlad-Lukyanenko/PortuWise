namespace PortuWise.WebClient.Domain.Responses
{
    public class GetWordResponse
    {
        public Guid CategoryId { get; set; }
        public string CategoryTitle { get; set; } = string.Empty;
        public Guid ParentCategoryId { get; set; }
        public string ParentCategoryTitle { get; set; } = string.Empty;
        public Word Word { get; set; } = null!;
        public List<Phrase> Phrases { get; set; } = null!;
    }
}
