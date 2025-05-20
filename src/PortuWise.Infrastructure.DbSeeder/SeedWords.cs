using Microsoft.EntityFrameworkCore;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PortuWise.Infrastructure.DbSeeder
{
    internal class SeedWords
    {
        private PortuWiseDbContext _dbContext;

        public SeedWords(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            var wordsJson = await File.ReadAllTextAsync("portuguese_words.json");

            var words = JsonSerializer.Deserialize<List<Word>>(wordsJson);

            foreach (var word in words)
            {
                var existingWord = await _dbContext.Words.FirstOrDefaultAsync(c => c.Id == word.Id);

                if (existingWord is null)
                {
                    word.CreatedAt = DateTime.UtcNow;
                    _dbContext.Words.Add(word);
                }
                else
                {
                    existingWord.Pt = word.Pt;
                    existingWord.PtTranscription = word.PtTranscription;
                    existingWord.Eng = word.Eng;
                    existingWord.EngTranscription = word.EngTranscription;
                    existingWord.Rus = word.Rus;
                    existingWord.CategoryId = word.CategoryId;
                    existingWord.ImagePath = word.ImagePath;
                    existingWord.UpdatedAt = DateTime.UtcNow;
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
