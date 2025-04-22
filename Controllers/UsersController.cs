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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            User? user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] string email)
        {
            return await _userService.CreateUserAsync(email);
        }

        [HttpPut("/subscription")]
        public async Task<ActionResult<User>> UpdateUserSubscription(
                string email,
                Subscription subscription
            )
        {
            if (await _userService.UpdateUserSubscriptionAsync(email, subscription))
            {
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("/database")]
        public async Task<ActionResult<User>> UpdateUserDb(
                string email,
                DbAdapter dbAdapter
            )
        {
            if (await _userService.UpdateUserDbAsync(email, dbAdapter))
            {
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public string GetHello()
        {
            return "hello world";
        }
    }
}
