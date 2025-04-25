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

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<Subscription>> GetUserSubscription(string userEmail)
        {
            User? user = await _userService.GetUserAsync(userEmail);
            if (user == null)
            {
                return NotFound();
            }
            return user.Subscription;
        }

        [HttpPut("{userEmail}")]
        public async Task<ActionResult<User>> UpdateUserSubscription(
                string userEmail,
                [FromBody]
                Subscription subscription
            )
        {
            if (await _userService.UpdateUserSubscriptionAsync(userEmail, subscription))
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
