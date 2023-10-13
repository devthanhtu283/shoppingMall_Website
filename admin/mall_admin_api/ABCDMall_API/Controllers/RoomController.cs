using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABCDMall_API.Controllers
{
    [Route("api/rooms")]
    public class RoomController : Controller
    {
        private RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult Add([FromBody] Room room)
        {
            try
            {
                return Ok(new
                {
                    status = _roomService.Add(room)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    status = _roomService.Delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_roomService.GetList());
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
                return Ok(_roomService.GetItem(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
