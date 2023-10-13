using DOANWEBAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOANWEBAPI.Controllers
{
	[Route("api/gallary")]
	public class GallaryController : Controller
	{	
		private GallaryService gallaryService;
		public GallaryController(GallaryService _gallaryService) {
			gallaryService= _gallaryService;
		}
		[Produces("application/json")]
		[Route("findAll")]
		public IActionResult findAll()
		{
			try
			{
				return Ok(gallaryService.findAll());
			}
			catch (Exception ex) { 
			return BadRequest(ex.Message);	
			}
		}
	}
}
