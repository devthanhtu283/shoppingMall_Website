
using DOANWEBAPI.Helpers;
using DOANWEBAPI.Models;
using DOANWEBAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;

namespace mall.Controllers
{
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private MovieService _movieService;
        private IWebHostEnvironment _webHostEnvironment;

        public MovieController(MovieService movieService, IWebHostEnvironment webHostEnvironment)
        {
            _movieService = movieService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("")]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_movieService.GetList());
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
                return Ok(_movieService.GetItem(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult AddFile(IFormFile file, string strMovie)
        {
            try
            {
                var fileName = FileHelper.generateFileName(file.FileName);
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
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
                    status = _movieService.Add(movie)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult UpdateFile(IFormFile file, string strMovie)
        {
            try
            {
                var movie = JsonConvert.DeserializeObject<Movie>(strMovie, new IsoDateTimeConverter
                {
                    DateTimeFormat = "dd/MM/yyyy"
                });

                var currentMovie = _movieService.Find(movie.Id);

                if (currentMovie == null)
                {
                    return Ok(new
                    {
                        status = "not found"
                    });
                }
                else
                {
                    if (file != null)
                    {
                        var fileName = FileHelper.generateFileName(file.FileName);
                        var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        movie.Photo = fileName;
                    }
                    else
                    {
                        movie.Photo = _movieService.Find(movie.Id).Photo;
                    }

                    return Ok(new
                    {
                        status = _movieService.Update(movie)
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpPut("delete/{id}")]
        public IActionResult Update(int id)
        {
            try
            {
                return Ok(new
                {
                    status = _movieService.Delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}


