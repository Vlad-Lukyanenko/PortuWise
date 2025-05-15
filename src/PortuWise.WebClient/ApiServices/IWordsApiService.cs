using PortuWise.WebClient.Domain.Responses;

namespace PortuWise.WebClient.ApiServices
{
    public interface IWordsApiService
    {
        Task<GetWordsResponse> GetWordsAsync(Guid categoryId);
        Task<GetWordResponse> GetWordAsync(Guid wordId);
    }
}
