using DOANWEBAPI.Models;
using DOANWEBAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace mall.Controllers
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
        [HttpGet("")]
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
        [HttpGet("date/{dateRelease}")]
        public IActionResult GetListByDateRelease(string dateRelease)
        {
            try
            {
                Debug.WriteLine(dateRelease);
                var dateReleaseDate = DateTime.ParseExact(dateRelease, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Debug.WriteLine(dateReleaseDate);
                return Ok(_showService.GetListByDateRelease(dateReleaseDate));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("{id}")]
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
