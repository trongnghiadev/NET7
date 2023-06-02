using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                User? user = await _userService.Register(registerViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
