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

        //private List<Word> _words;

        //public WordService()
        //{
        //    _words = new List<Word>()
        //    {
        //        new Word()
        //        {
        //            Id = Guid.Parse("94f3cef5-c349-47f4-bfee-9630d07c98cd"),
        //            CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
        //            ImagePath = "./images/words/hello.png",
        //            Pt = "Olá",
        //            PtTranscription = "/ɔˈla/",
        //            Eng = "Hello",
        //            EngTranscription = "/həˈləʊ/",
        //            Rus = "Привет"
        //        },
        //        new Word()
        //        {
        //            Id = Guid.Parse("7eb9a398-1458-4707-973a-5014b694d90e"),
        //            CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
        //            ImagePath = "./images/words/hello.png",
        //            Pt = "Bom dia",
        //            PtTranscription = "/bõ ˈdi.ɐ/",
        //            Eng = "Good morning",
        //            EngTranscription = "/ɡʊd ˈmɔːrnɪŋ/",
        //            Rus = "Доброе утро"
        //        },
        //        new Word()
        //        {
        //            Id = Guid.Parse("ff1b8dc9-438a-46cd-95bc-0a355c5ea595"),
        //            CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
        //            ImagePath = "./images/words/hello.png",
        //            Pt = "Boa tarde",
        //            PtTranscription = "/ˈbo.ɐ ˈtaɾ.dɨ/",
        //            Eng = "Good afternoon",
        //            EngTranscription = "/ɡʊd ˌæftərˈnuːn/",
        //            Rus = "Добрый день"
        //        },
        //        new Word()
        //        {
        //            Id = Guid.Parse("85cf5698-2c83-4632-8017-06aa9e865859"),
        //            CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
        //            ImagePath = "./images/words/hello.png",
        //            Pt = "Boa noite",
        //            PtTranscription = "/ˈbo.ɐ ˈnoj.tɨ/",
        //            Eng = "Good evening",
        //            EngTranscription = "/ɡʊd ˈiːvnɪŋ/",
        //            Rus = "Добрый вечер "
        //        }
        //    };
        //}

        public async Task<List<Word>> GetWords(Guid categoryId)
        {
            var words = await _dbContext.Words.OrderBy(c => c.CreatedAt).ToListAsync();

            return words;
        }

        public async Task<Word> GetWord(Guid wordId)
        {
            return await _dbContext.Words.SingleAsync(c => c.Id == wordId);
        }
    }
}
