using Microsoft.EntityFrameworkCore;
using PortuWise.Application.Services;
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

        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

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

        public async Task<List<Category>> GetSubcategoriesAsync(Guid categoryId)
        {
            var categories = await _dbContext.Categories.OrderBy(c => c.CreatedAt).Where(c => c.ParentId == categoryId).ToListAsync();

            return categories;
        }
    }
}
