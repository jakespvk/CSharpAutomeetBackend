using Microsoft.AspNetCore.Mvc;

namespace AutomeetBackend
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<User>> GetUser(string userEmail)
        {
            User? user = await _userService.GetUserAsync(userEmail);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] string email)
        {
            return await _userService.CreateUserAsync(email);
        }

        [HttpGet]
        public string GetHello()
        {
            return "hello world";
        }
    }
}
