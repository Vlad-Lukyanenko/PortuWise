using Microsoft.EntityFrameworkCore;
using PortuWise.Application.Services;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.WebApi.Services
{
    public class LessonService : ILessonService
    {
        private PortuWiseDbContext _dbContext;

        public LessonService(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Lesson?> GetLesson(Guid categoryId)
        {
            return await _dbContext.Lessons.SingleOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}
