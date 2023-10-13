using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABCDMall_API.Controllers
{
    [Route("api/category")]

    public class CategoryController : Controller
    {
        private CategoryService categoryService;

        public CategoryController(CategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(categoryService.findAll());
            }
            catch 
            {
                return BadRequest();
            }
        }
        
    }
}
