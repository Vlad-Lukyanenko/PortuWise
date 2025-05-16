using PortuWise.Contracts.Responses;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse?> GetCategoryByIdAsync(Guid categoryId);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<List<Category>>GetRootCategoriesAsync();

        Task<List<GetCategoryResponse>> GetSubcategoriesAsync(Guid categoryId);
    }
}
