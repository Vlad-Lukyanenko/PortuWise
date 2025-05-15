using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.WebApi.Domain.Responses
{
    public class GetWordResponse
    {
        public Word Word { get; set; } = null!;
        public List<Phrase> Phrases { get; set; } = null!;
    }
}
