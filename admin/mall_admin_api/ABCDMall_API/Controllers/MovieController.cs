using ABCDMall_API.Helpers;
using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ABCDMall_API.Controllers
{
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private MovieService movieService;
        private IWebHostEnvironment _webHostEnvironment;

        public MovieController(MovieService _movieService, IWebHostEnvironment webHostEnvironment)
        {
            movieService = _movieService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(movieService.findAll());
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
                return Ok(movieService.findbyId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPost("create2")]
        public IActionResult Create2(IFormFile file, string strMovie)
        {
            try
            {
                var fileName = FileHelper.generateFileName(file.FileName);
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var movie = JsonConvert.DeserializeObject<Movie>(strMovie, new IsoDateTimeConverter
                {
                    DateTimeFormat = "dd/MM/yyyy"
                });

                movie.Photo = fileName;
                return Ok(new
                {
                    status = movieService.create(movie)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Movie movie)
        {
            try
            {
                return Ok(new
                {
                    status = movieService.update(movie)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPut("update2")]
        public IActionResult Update2(IFormFile file, string strMovie)
        {
            try
            {
                var movie = JsonConvert.DeserializeObject<Movie>(strMovie);
                if (file != null)
                {
                    var fileName = FileHelper.generateFileName(file.FileName);
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    movie.Photo = fileName;
                }
                else
                {
                    movie.Photo = movieService.findbyId2(movie.Id).Image;
                }

                return Ok(new
                {
                    status = movieService.update(movie)
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
                    status = movieService.delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findByKeyword/{keyword}")]
        public IActionResult FindByKeyword(string keyword)
        {
            try
            {
                return Ok(movieService.findByKeyword(keyword));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}


