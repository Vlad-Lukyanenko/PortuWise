using Microsoft.AspNetCore.Mvc;
using PortuWise.Application.Services;
using PortuWise.WebApi.Domain.Responses;
using PortuWise.WebApi.Services;

namespace PortuWise.WebApi.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly ICategoryService _categoryService;

        public LessonsController(ILessonService lessonService, ICategoryService categoryService)
        {
            _lessonService = lessonService;
            _categoryService = categoryService;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get(Guid categoryId)
        {
            var lesson = _lessonService.GetLesson(categoryId);
            var parentCategory = await _categoryService.GetCategoryByIdAsync(categoryId);

            var response = new GetLessonResponse()
            {
                Id = lesson.Id,
                CategoryId = lesson.CategoryId,
                LessonHtml = lesson.LessonHtml,
                ParentCategoryId = parentCategory!.Id
            };

            return Ok(response);
        }
    }
}
