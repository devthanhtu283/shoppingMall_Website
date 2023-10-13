using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABCDMall_API.Controllers
{
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        private TicketService _ticketService;
        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult Add([FromBody] Ticket[] tickets)
        {
            if (tickets == null || tickets.Length == 0)
            {
                return BadRequest("data sent is empty");
            }
            else
            {
                try
                {
                    return Ok(new
                    {
                        status = _ticketService.Add(tickets)
                    });
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
        [Produces("application/json")]
        [HttpGet("getitem/{id}")]
        public IActionResult GetItem(int id)
        {
            try
            {
                return Ok(_ticketService.GetItem(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getlistbycustomername/{customerName}")]
        public IActionResult GetListByCustomerName(string customerName)
        {
            try
            {
                return Ok(_ticketService.GetListByCustomerName(customerName));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("getlistbycustomerphone/{customerPhone}")]
        public IActionResult GetListByCustomerPhone(string customerPhone)
        {
            try
            {
                return Ok(_ticketService.GetListByCustomerPhone(customerPhone));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_ticketService.GetList());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
