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

        [HttpGet("/{userId}")]
        public async Task<ActionResult<Subscription>> GetUserSubscription(Guid userId)
        {
            User? user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return user.Subscription;
        }

    }
}
