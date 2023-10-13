using Microsoft.AspNetCore.Mvc;
using DOANWEBAPI.Services;

namespace DOANWEBAPI.Controllers
{
    [Route("api/product")]
    public class productController : Controller
    {
        private productService productService;
        public productController(productService _productService)
        {
            this.productService = _productService;
        }
        [Produces("application/json")]
        [Route("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(productService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }
		[Produces("application/json")]
		[Route("findByName/{name}")]
		public IActionResult findByName(string name)
		{
			try
			{
				return Ok(productService.findByName(name));
			}
			catch
			{
				return BadRequest();
			}
		}
		[Produces("application/json")]
		[Route("asc")]
		public IActionResult Asc()
		{
			try
			{
				return Ok(productService.Asc());
			}
			catch
			{
				return BadRequest();
			}
		}
		[Produces("application/json")]
		[Route("desc")]
		public IActionResult Desc()
		{
			try
			{
				return Ok(productService.Desc());
			}
			catch
			{
				return BadRequest();
			}
		}
        [Produces("application/json")]
        [Route("sale")]
        public IActionResult Sale()
        {
            try
            {
                return Ok(productService.Sale());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
