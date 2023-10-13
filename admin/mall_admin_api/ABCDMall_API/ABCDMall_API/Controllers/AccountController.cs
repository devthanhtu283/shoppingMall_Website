using ABCDMall_API.Helpers;
using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ABCDMall_API.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private AccountService accountService;

        public AccountController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [Produces("application/json")]
        [HttpGet("login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                return Ok(accountService.login(username, password));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
