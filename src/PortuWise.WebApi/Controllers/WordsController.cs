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
            var words = await _wordService.GetWords(categoryId);
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            var response = new GetWordsResponse()
            {
                CategoryId = categoryId,
                CategoryTitle = category.Title,
                ParentCategoryId = category!.ParentId!.Value,
                ParentCategoryTitle = category.ParentTitle,
                Words = words
            };

            return Ok(response);
        }

        [HttpGet("words/{wordId}")]
        public async Task<IActionResult> Get(Guid wordId)
        {
            var word = await _wordService.GetWord(wordId);
            var category = await _categoryService.GetCategoryByIdAsync(word.CategoryId);
            //var phrases = await _phraseService.GetPhrases(wordId);

            var response = new GetWordResponse()
            {
                CategoryId = category.Id,
                CategoryTitle = category.Title,
                ParentCategoryId = category!.ParentId!.Value,
                ParentCategoryTitle = category.ParentTitle,
                Word = word,
                //Phrases = phrases
            };

            return Ok(response);
        }
    }
}
