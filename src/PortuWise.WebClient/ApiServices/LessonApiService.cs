using PortuWise.WebClient.Domain.Responses;
using System.Net.Http.Json;

namespace PortuWise.WebClient.ApiServices
{
    public class LessonApiService : ILessonApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public LessonApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = "api/lessons";
        }

        public async Task<GetLessonResponse> GetLessonAsync(Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{categoryId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<GetLessonResponse>();
        }
    }
}
