using Microsoft.AspNetCore.Mvc;
using PortuWise.Application.Services;
using PortuWise.WebApi.Domain.Responses;

namespace PortuWise.WebApi.Controllers
{
    [ApiController]
    [Route("api/words")]
    public class WordsController : ControllerBase
    {
        private readonly IWordService _wordService;
        private readonly IPhraseService _phraseService;
        private readonly ICategoryService _categoryService;

        public WordsController(
            IWordService wordService,
            IPhraseService phraseService,
            ICategoryService categoryService)
        {
            _wordService = wordService;
            _phraseService = phraseService;
            _categoryService = categoryService;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetAll(Guid categoryId)
        {
            var words = _wordService.GetWords(categoryId);
            var parentCategory = await _categoryService.GetCategoryByIdAsync(categoryId);

            var response = new GetWordsResponse()
            {
                CategoryId = categoryId,
                ParentCategoryId = parentCategory!.Id,
                Words = words
            };

            await Task.Delay(10);

            return Ok(response);
        }

        [HttpGet("words/{wordId}")]
        public async Task<IActionResult> Get(Guid wordId)
        {
            var word = _wordService.GetWord(wordId);
            var phrases = _phraseService.GetPhrases(wordId);

            await Task.Delay(10);

            var response = new GetWordResponse()
            {
                Word = word,
                Phrases = phrases
            };

            return Ok(response);
        }
    }
}
