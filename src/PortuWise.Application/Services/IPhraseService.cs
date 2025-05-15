using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface IPhraseService
    {
        List<Phrase> GetPhrases(Guid wordId);
    }
}
