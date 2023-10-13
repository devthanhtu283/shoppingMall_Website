using Microsoft.AspNetCore.Mvc;
using DOANWEBAPI.Services;

namespace DOANWEBAPI.Controllers
{
    [Route("api/shop")]
    public class shopController : Controller
    {
        private shopService shopService;
        public shopController(shopService _shopService)
        {
            this.shopService = _shopService;
        }

        [Produces("application/json")]
        [Route("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(shopService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Route("findByCategoryID/{id}")]
        public IActionResult findByCategoryID(int id)
        {
            try
            {
                return Ok(shopService.findByCategoryID(id));
            }
            catch
            {
                return BadRequest();
            }


        }
		[Produces("application/json")]
		[Route("findByName/{name}/{categoryID}")]
		public IActionResult findByName(string name,int categoryID)
		{
			try
			{
				return Ok(shopService.findByName(name, categoryID));
			}
			catch
			{
				return BadRequest();
			}


		}
	}
}
