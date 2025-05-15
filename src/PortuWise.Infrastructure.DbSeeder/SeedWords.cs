using Microsoft.EntityFrameworkCore;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Infrastructure.DbSeeder
{
    internal class SeedWords
    {
        private PortuWiseDbContext _dbContext;

        private List<Word> _words;

        public SeedWords(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;

            _words = new List<Word>()
            {
                new Word()
                {
                    Id = Guid.Parse("94f3cef5-c349-47f4-bfee-9630d07c98cd"),
                    CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
                    ImagePath = "./images/words/hello.png",
                    Pt = "Olá",
                    PtTranscription = "/ɔˈla/",
                    Eng = "Hello",
                    EngTranscription = "/həˈləʊ/",
                    Rus = "Привет",
                    CreatedAt = DateTime.UtcNow,
                },
                new Word()
                {
                    Id = Guid.Parse("7eb9a398-1458-4707-973a-5014b694d90e"),
                    CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
                    ImagePath = "./images/words/hello.png",
                    Pt = "Bom dia",
                    PtTranscription = "/bõ ˈdi.ɐ/",
                    Eng = "Good morning",
                    EngTranscription = "/ɡʊd ˈmɔːrnɪŋ/",
                    Rus = "Доброе утро",
                    CreatedAt = DateTime.UtcNow,
                },
                new Word()
                {
                    Id = Guid.Parse("ff1b8dc9-438a-46cd-95bc-0a355c5ea595"),
                    CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
                    ImagePath = "./images/words/hello.png",
                    Pt = "Boa tarde",
                    PtTranscription = "/ˈbo.ɐ ˈtaɾ.dɨ/",
                    Eng = "Good afternoon",
                    EngTranscription = "/ɡʊd ˌæftərˈnuːn/",
                    Rus = "Добрый день",
                    CreatedAt = DateTime.UtcNow,
                },
                new Word()
                {
                    Id = Guid.Parse("85cf5698-2c83-4632-8017-06aa9e865859"),
                    CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
                    ImagePath = "./images/words/hello.png",
                    Pt = "Boa noite",
                    PtTranscription = "/ˈbo.ɐ ˈnoj.tɨ/",
                    Eng = "Good evening",
                    EngTranscription = "/ɡʊd ˈiːvnɪŋ/",
                    Rus = "Добрый вечер",
                    CreatedAt = DateTime.UtcNow,
                }
            };
        }

        public async Task Seed()
        {
            foreach (var word in _words)
            {
                var existingWord = await _dbContext.Words.FirstOrDefaultAsync(c => c.Id == word.Id);

                if (existingWord is null)
                {
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
