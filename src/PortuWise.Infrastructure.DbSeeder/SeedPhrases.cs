using Microsoft.EntityFrameworkCore;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Infrastructure.DbSeeder
{
    internal class SeedPhrases
    {
        private PortuWiseDbContext _dbContext;
        private List<Phrase> _phrases;

        public SeedPhrases(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;

            _phrases = new List<Phrase>()
            {
                new Phrase()
                {
                    Id = Guid.Parse("979f8e95-c7c2-4f7e-beb4-bd0f70646a42"),
                    WordId = Guid.Parse("94f3cef5-c349-47f4-bfee-9630d07c98cd"),
                    Pt = "Olá! Como estás?",
                    PtTranscription = "/ɔˈla ˈko.mu ʃˈtaʃ/",
                    Eng = "Hello! How are you?",
                    EngTranscription = "/həˈləʊ | haʊ ɑː juː/",
                    Rus = "Привет! Как ты?",
                    CreatedAt = DateTime.UtcNow,
                },
                new Phrase()
                {
                    Id = Guid.Parse("ca68ff8f-bc80-452c-ab3b-fcc363377da8"),
                    WordId = Guid.Parse("94f3cef5-c349-47f4-bfee-9630d07c98cd"),
                    Pt = "Olá, tudo bem contigo?",
                    PtTranscription = "/ɔˈla ˈtu.du bẽj kõˈti.ɡu/",
                    Eng = "Hello, is everything good with you?",
                    EngTranscription = "/həˈləʊ | ɪz ˈɛv.ri.θɪŋ ɡʊd wɪð juː/",
                    Rus = "Привет, всё хорошо у тебя?",
                    CreatedAt = DateTime.UtcNow,

                },
                new Phrase()
                {
                    Id = Guid.Parse("0c848fc9-5c78-44a9-9aba-ca80ca5091a4"),
                    WordId = Guid.Parse("94f3cef5-c349-47f4-bfee-9630d07c98cd"),
                    Pt = "Olá a todos!",
                    PtTranscription = "/ɔˈla ɐ ˈto.duʃ/",
                    Eng = "Hello everyone!",
                    EngTranscription = "/həˈləʊ ˈev.ri.wʌn/",
                    Rus = "Всем привет!",
                    CreatedAt = DateTime.UtcNow,
                }
            };
        }

        public async Task Seed()
        {
            foreach (var phrase in _phrases)
            {
                var existingPhrase = await _dbContext.Phrases.FirstOrDefaultAsync(c => c.Id == phrase.Id);

                if (existingPhrase is null)
                {
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
