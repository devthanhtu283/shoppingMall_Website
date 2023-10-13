using ABCDMall_API.Helpers;
using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ABCDMall_API.Controllers
{
    [Route("api/store")]
    public class StoreController : Controller
    {
        private StoreService storeService;
        private IWebHostEnvironment webHostEnvironment;
        public StoreController(StoreService _storeService, IWebHostEnvironment _webHostEnvironment) 
        {
            storeService = _storeService;
            webHostEnvironment = _webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(storeService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("create")]
        public IActionResult Create([FromBody] Shop shop)
        {
            try
            {
                return Ok(new 
                {
                    status = storeService.create(shop)
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
        public IActionResult Create2(IFormFile file, string strStore)
        {
            try
            {
                var fileName = FileHelper.generateFileName(file.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var store = JsonConvert.DeserializeObject<Shop>(strStore);
                store.CoverImg = fileName;
                return Ok(new
                {
                    status = storeService.create(store)
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
                    status = storeService.delete(id)
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
                return Ok(storeService.findByKeyword(keyword));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Shop shop)
        {
            try
            {
                return Ok(new
                {
                    status = storeService.update(shop)
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
        public IActionResult Update2(IFormFile file, string strStore)
        {
            try
            {
                var store = JsonConvert.DeserializeObject<Shop>(strStore);
                if (file != null)
                {
                    var fileName = FileHelper.generateFileName(file.FileName);
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "img", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    store.CoverImg = fileName;
                }
                else
                {
                    store.CoverImg = storeService.findById2(store.Id).CoverImg;
                }

                return Ok(new
                {
                    status = storeService.update(store)
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
                return Ok(storeService.findById(id));
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
