using Microsoft.EntityFrameworkCore;
using PortuWise.Application.Services;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.WebApi.Services
{
    public class PhraseService : IPhraseService
    {
        private PortuWiseDbContext _dbContext;

        public PhraseService(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Phrase>> GetPhrases(Guid wordId)
        {
            return _dbContext.Phrases.Where(c => c.WordId == wordId).OrderBy(c => c.CreatedAt).ToListAsync();
        }
    }
}
