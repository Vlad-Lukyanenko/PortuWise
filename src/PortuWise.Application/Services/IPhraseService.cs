using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface IPhraseService
    {
        Task<List<Phrase>> GetPhrases(Guid wordId);
    }
}
