using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface IWordService
    {
        Task<List<Word>> GetWords(Guid categoryId);

        Task<Word> GetWord(Guid wordId);
    }
}
