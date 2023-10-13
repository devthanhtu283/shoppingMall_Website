using DOANWEBAPI.Models;
using DOANWEBAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace mall.Controllers
{
    [Route("api/timeslots")]
    public class TimeSlotController : Controller
    {
        private TimeSlotService _timeSlotService;

        public TimeSlotController(TimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult Add([FromBody] TimeSlot timeSlot)
        {
            try
            {
                return Ok(new
                {
                    status = _timeSlotService.Add(timeSlot)
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
        public IActionResult Update([FromBody] TimeSlot timeSlot)
        {
            try
            {
                return Ok(new
                {
                    status = _timeSlotService.Update(timeSlot)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    status = _timeSlotService.Delete(id)
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
                return Ok(_timeSlotService.GetList());
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
                return Ok(_timeSlotService.GetItem(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
