using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface IWordService
    {
        List<Word> GetWords(Guid categoryId);

        Word GetWord(Guid wordId);
    }
}
