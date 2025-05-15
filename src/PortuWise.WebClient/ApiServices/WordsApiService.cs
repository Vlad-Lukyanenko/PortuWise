using PortuWise.WebClient.Domain.Responses;
using System.Net.Http.Json;

namespace PortuWise.WebClient.ApiServices
{
    public class WordsApiService : IWordsApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public WordsApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = "api/words";
        }

        public async Task<GetWordResponse> GetWordAsync(Guid wordId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/words/{wordId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<GetWordResponse>();
        }

        public async Task<GetWordsResponse> GetWordsAsync(Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{categoryId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<GetWordsResponse>();
        }
    }
}
