using Microsoft.AspNetCore.Mvc;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly UserService _userService;

        public SubscriptionController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Subscription>> GetUserSubscription(string email)
        {
            User? user = await _userService.GetUserAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return user.Subscription;
        }

        [HttpPut]
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
    }
}
