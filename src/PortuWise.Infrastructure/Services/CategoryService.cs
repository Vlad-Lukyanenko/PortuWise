using Microsoft.EntityFrameworkCore;
using PortuWise.Application.Services;
using PortuWise.Contracts.Responses;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.WebApi.Services
{
    public class CategoryService : ICategoryService
    {

        private PortuWiseDbContext _dbContext;

        public CategoryService(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;


        }

        public async Task<GetCategoryResponse?> GetCategoryByIdAsync(Guid categoryId)
        {
            var category = await _dbContext.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new GetCategoryResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImagePath = c.ImagePath,
                    Description = c.Description,
                    ParentId = c.ParentId,
                    ParentTitle = c.Parent != null ? c.Parent.Title : null
                })
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories.OrderBy(c => c.CreatedAt).ToListAsync();

            return categories;
        }

        public async Task<List<Category>> GetRootCategoriesAsync()
        {
            var categories = await _dbContext.Categories.OrderBy(c => c.CreatedAt).Where(c => c.ParentId == null).ToListAsync();

            return categories;
        }

        public async Task<List<GetCategoryResponse>> GetSubcategoriesAsync(Guid categoryId)
        {
            var categories = await _dbContext.Categories
                .Where(c => c.ParentId == categoryId)
                .OrderBy(c => c.CreatedAt)
                .Select(c => new GetCategoryResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImagePath = c.ImagePath,
                    Description = c.Description,
                    ParentId = c.ParentId,
                    ParentTitle = c.Parent != null ? c.Parent.Title : null
                })
                .ToListAsync();

            return categories;
        }
    }
}
