using PortuWise.WebClient.Domain;

namespace PortuWise.WebClient.Domain.Responses
{
    public class GetWordsResponse
    {
        public Guid CategoryId { get; set; }
        public Guid ParentCategoryId { get; set; }
        public List<Word> Words { get; set; } = null!;
    }
}
