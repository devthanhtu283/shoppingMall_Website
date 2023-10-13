using ABCDMall_API.Helpers;
using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ABCDMall_API.Controllers
{
    [Route("api/gallery")]
    public class GalleryController : Controller
    {
        private GalleryService galleryService;
        private IWebHostEnvironment webHostEnvironment;

        public GalleryController(GalleryService _galleryService, IWebHostEnvironment _webHostEnvironment)
        {
            galleryService = _galleryService;
            webHostEnvironment = _webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(galleryService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("create")]
        public IActionResult Create([FromBody] Newsgallery newsgallery)
        {
            try
            {
                return Ok(new
                {
                    status = galleryService.create(newsgallery)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPost("create2")]
        public IActionResult Create2(IFormFile file, string strGallery)
        {
            try
            {
                var fileName = FileHelper.generateFileName(file.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var gallery = JsonConvert.DeserializeObject<Newsgallery>(strGallery);
                gallery.CoverImg = fileName;
                return Ok(new
                {
                    status = galleryService.create(gallery)
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
                    status = galleryService.delete(id)
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
                return Ok(galleryService.findById(id));
            }
            catch
            {

                return BadRequest();
            }
        }

        
        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPut("update2")]
        public IActionResult Update2(IFormFile file, string strGallery)
        {
            try
            {
                var gallery = JsonConvert.DeserializeObject<Newsgallery>(strGallery);
                if (file != null)
                {
                    var fileName = FileHelper.generateFileName(file.FileName);
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "img", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    gallery.CoverImg = fileName;
                }
                else
                {
                    gallery.CoverImg = galleryService.findById2(gallery.Id).CoverImg;
                }

                return Ok(new
                {
                    status = galleryService.update(gallery)
                });
            }
            catch
            {

                return BadRequest();
            }
        } 
        
    }
}
