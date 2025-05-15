using Microsoft.AspNetCore.Mvc;
using PortuWise.Application.Services;

namespace PortuWise.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("root")]
        public async Task<IActionResult> GetRoot()
        {
            var categories = await _categoryService.GetRootCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("{categoryId}/subcategories")]
        public async Task<IActionResult> GetSubcategories([FromRoute] Guid categoryId)
        {
            var categories = await _categoryService.GetSubcategoriesAsync(categoryId);

            return Ok(categories);
        }
    }
}
