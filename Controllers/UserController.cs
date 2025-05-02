using AutomeetBackend.Models;
using AutomeetBackend.Services;
using AutomeetBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly UserService _userService;

        public UserController(UserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<User>> GetUser(string userEmail)
        {
            User user;
            try
            {
                user = await _userRepository.GetUserAsync(userEmail);
            }
            catch (Exception err)
            {
                Console.WriteLine("err:", err.Message);
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] string email)
        {
            return await _userRepository.CreateUserAsync(email);
        }

        [HttpGet]
        public string GetHello()
        {
            return "hello world";
        }
    }
}
