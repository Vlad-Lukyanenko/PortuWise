using PortuWise.WebClient.Domain;

namespace PortuWise.WebClient.ApiServices
{
    public interface ICategoryApiService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetRootCategoriesAsync();
        Task<IEnumerable<Category>> GetSubcategoriesAsync(Guid categoryId);
    }
}
