using DOANWEBAPI.Models;
using DOANWEBAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace mall.Controllers
{
    [Route("api/seats")]
    public class SeatController : Controller
    {
        public SeatService _seatService;
        public SeatController(SeatService seatService)
        {
            _seatService = seatService;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Seat seat)
        {
            try
            {
                return Ok(new
                {
                    status = _seatService.Update(seat)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
