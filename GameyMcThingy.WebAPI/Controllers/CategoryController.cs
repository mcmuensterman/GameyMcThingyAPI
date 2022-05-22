using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Models.Category;
using GameyMcThingy.Services.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameyMcThingy.WebAPI.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _categoryService.CreateCategoryAsync(request))
                return Ok("New Category Created");

            return BadRequest("Error - Please try again");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int categoryId)
        {
            var detail = await _categoryService.GetCategoryByIdAsync(categoryId);

            //using ternary to determine return type, if null return 404, otherwise 200 OK
            return detail is not null
                ? Ok(detail)
                : NotFound();
        }

         [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            return await _categoryService.DeleteCategoryAsync(categoryId)
                ? Ok ($"Category {categoryId} Deleted")
                : BadRequest("Error - Please try again");
        }
    }
}