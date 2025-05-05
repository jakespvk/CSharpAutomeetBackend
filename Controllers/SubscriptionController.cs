using AutomeetBackend.Services;
using AutomeetBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            try
            {
                User user = await _userService.TryGetUserAsync(userEmail);
                return user.Subscription;
            }
            catch (Exception err)
            {
                Console.WriteLine("err:", err.Message);
                return NotFound();
            }
        }

        // check with Kostya about this and the changes to UserService
        // to me, this seems much simpler and clearer control flow
        [HttpPut("{userEmail}")]
        public async Task<ActionResult<User>> UpdateUserSubscription(
                string userEmail,
                [FromBody]
                Subscription subscription
            )
        {
            try
            {
                await _userService.TryUpdateUserSubscriptionAsync(userEmail, subscription);
                return Accepted();
            }
            catch (Exception e)
            {
                Console.WriteLine("error:", e.Message);
                return NotFound();
            }
        }

    }
}
