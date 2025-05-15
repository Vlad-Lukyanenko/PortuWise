using PortuWise.WebClient.Domain.Responses;

namespace PortuWise.WebClient.ApiServices
{
    public interface ILessonApiService
    {
        Task<GetLessonResponse> GetLessonAsync(Guid categoryId);
    }
}
