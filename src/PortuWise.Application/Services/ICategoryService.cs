using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface ICategoryService
    {
        Task<Category?> GetCategoryByIdAsync(Guid categoryId);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<List<Category>>GetRootCategoriesAsync();

        Task<List<Category>> GetSubcategoriesAsync(Guid categoryId);
    }
}
