using PortuWise.WebClient.Domain;
using System.Net.Http.Json;

namespace PortuWise.WebClient.ApiServices
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CategoryApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = "api/categories";
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/all");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
        }

        public async Task<IEnumerable<Category>> GetRootCategoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/root");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
        }

        public async Task<IEnumerable<Category>> GetSubcategoriesAsync(Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{categoryId}/subcategories");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
        }
    }
}
