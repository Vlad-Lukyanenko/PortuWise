using PortuWise.WebClient.Domain;

namespace PortuWise.WebClient.Domain.Responses
{
    public class GetWordResponse
    {
        public Word Word { get; set; } = null!;
        public List<Phrase> Phrases { get; set; } = null!;
    }
}
