using Microsoft.EntityFrameworkCore;
using PortuWise.Application.Services;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.WebApi.Services
{
    public class WordService : IWordService
    {
        private PortuWiseDbContext _dbContext;

        public WordService(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Word>> GetWords(Guid categoryId)
        {
            var words = await _dbContext.Words.Include(w => w.Phrases).Where(c => c.CategoryId == categoryId).OrderBy(c => c.CreatedAt).ToListAsync();

            return words;
        }

        public async Task<Word> GetWord(Guid wordId)
        {
            return await _dbContext.Words.Include(w => w.Phrases).SingleAsync(c => c.Id == wordId);
        }
    }
}
