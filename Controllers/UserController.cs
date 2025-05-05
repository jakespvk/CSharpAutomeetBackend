using AutomeetBackend.Models;
using AutomeetBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<User>> GetUser(string userEmail)
        {
            try
            {
                return await _userService.TryGetUserAsync(userEmail);
            }
            catch (Exception err)
            {
                Console.WriteLine("err:", err.Message);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] string email)
        {
            try
            {
                return await _userService.TryCreateUserAsync(email);
            }
            catch (Exception err)
            {
                Console.WriteLine("err:", err.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public string GetHello()
        {
            return "hello world";
        }
    }
}
