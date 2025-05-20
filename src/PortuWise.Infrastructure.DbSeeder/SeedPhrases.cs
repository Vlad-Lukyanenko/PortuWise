using Microsoft.EntityFrameworkCore;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;
using System.Text.Json;

namespace PortuWise.Infrastructure.DbSeeder
{
    internal class SeedPhrases
    {
        private PortuWiseDbContext _dbContext;

        public SeedPhrases(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            var phrasesJson = await File.ReadAllTextAsync("portuguese_phrases.json");

            var phrases = JsonSerializer.Deserialize<List<Phrase>>(phrasesJson)!;

            foreach (var phrase in phrases)
            {
                var existingPhrase = await _dbContext.Phrases.FirstOrDefaultAsync(c => c.Id == phrase.Id);

                if (existingPhrase is null)
                {
                    phrase.CreatedAt = DateTime.UtcNow;
                    _dbContext.Phrases.Add(phrase);
                }
                else
                {
                    existingPhrase.WordId = phrase.WordId;
                    existingPhrase.Pt = phrase.Pt;
                    existingPhrase.PtTranscription = phrase.PtTranscription;
                    existingPhrase.Eng = phrase.Eng;
                    existingPhrase.EngTranscription = phrase.EngTranscription;
                    existingPhrase.Rus = phrase.Rus;
                    existingPhrase.UpdatedAt = DateTime.UtcNow;
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
