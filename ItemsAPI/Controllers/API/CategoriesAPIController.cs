using ItemsAPI.Data.Model;
using ItemsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemsAPI.Controllers.API
{
    [Route("api/")]
    [ApiController]
    public class CategoriesAPIController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesAPIController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var result = await this.categoryService.CreateCategoryAsync(category);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IEnumerable<string>> GetAllCategories()
        {
            var result = await this.categoryService.GetAllCategoriesAsync();

            return result;
        }
    }
}
