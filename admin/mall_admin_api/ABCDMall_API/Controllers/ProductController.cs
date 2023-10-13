using ABCDMall_API.Helpers;
using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ABCDMall_API.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private ProductService productservice;
        private IWebHostEnvironment webHostEnvironment;

        public ProductController(ProductService _productservice, IWebHostEnvironment _webHostEnvironment) 
        {
            productservice = _productservice;
            webHostEnvironment = _webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(productservice.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Product product)
        {
            try
            {
                return Ok(new
                {
                    status = productservice.create(product)
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
        public IActionResult Create2(IFormFile file, string strProduct)
        {
            try
            {
                var fileName = FileHelper.generateFileName(file.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var product = JsonConvert.DeserializeObject<Product>(strProduct);
                product.Image = fileName;
                return Ok(new
                {
                    status = productservice.create(product)
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
                    status = productservice.delete(id)
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
        public IActionResult Update([FromBody] Product product)
        {
            try
            {
                return Ok(new
                {
                    status = productservice.update(product)
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
        public IActionResult Update2(IFormFile file, string strProduct)
        {
            try
            {
                var product = JsonConvert.DeserializeObject<Product>(strProduct);
                if (file != null)
                {
                    var fileName = FileHelper.generateFileName(file.FileName);
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "img", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    product.Image = fileName;
                }
                else
                {
                    product.Image = productservice.findById2(product.Id).Image;
                }

                return Ok(new
                {
                    status = productservice.update(product)
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
                return Ok(productservice.findByKeyword(keyword));
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
                return Ok(productservice.findById(id));
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
