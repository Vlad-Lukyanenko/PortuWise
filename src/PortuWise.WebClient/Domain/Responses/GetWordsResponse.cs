namespace PortuWise.WebClient.Domain.Responses
{
    public class GetWordsResponse
    {
        public Guid CategoryId { get; set; }
        public string CategoryTitle { get; set; } = string.Empty;
        public Guid ParentCategoryId { get; set; }
        public string ParentCategoryTitle { get; set; } = string.Empty;
        public List<Word> Words { get; set; } = null!;
    }
}
