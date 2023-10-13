using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABCDMall_API.Controllers
{
    [Route("api/shows")]
    public class ShowController : Controller
    {
        private ShowService _showService;
        public ShowController(ShowService showService)
        {
            _showService = showService;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult Add([FromBody] Show show)
        {
            try
            {
                return Ok(new
                {
                    status = _showService.Add(show)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    status = _showService.Delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_showService.GetList());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("getitem/{id}")]
        public IActionResult GetItem(int id)
        {
            try
            {
                return Ok(_showService.GetItem(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
