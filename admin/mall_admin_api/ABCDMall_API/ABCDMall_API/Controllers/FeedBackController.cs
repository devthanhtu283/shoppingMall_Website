using ABCDMall_API.Helpers;
using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ABCDMall_API.Controllers
{
    [Route("api/feedback")]
    public class FeedBackController : Controller
    {
        private FeedBackService feedbackService;
        private IWebHostEnvironment webHostEnvironment;

        public FeedBackController(FeedBackService _feedbackService, IWebHostEnvironment _webHostEnvironment)
        {
            feedbackService = _feedbackService;
            webHostEnvironment = _webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(feedbackService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("create")]
        public IActionResult Create([FromBody] Feedback feedback)
        {
            try
            {
                return Ok(new
                {
                    status = feedbackService.create(feedback)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    status = feedbackService.delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public IActionResult Find(int id)
        {
            try
            {
                return Ok(feedbackService.findById(id));
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
