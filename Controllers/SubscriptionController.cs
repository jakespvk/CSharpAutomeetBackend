using AutomeetBackend.Services;
using AutomeetBackend.Repositories;
using AutomeetBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly UserService _userService;

        public SubscriptionController(UserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<Subscription>> GetUserSubscription(string userEmail)
        {
            User? user = await _userRepository.GetUserAsync(userEmail);
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
            if (await _userService.TryUpdateUserSubscriptionAsync(userEmail, subscription))
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
