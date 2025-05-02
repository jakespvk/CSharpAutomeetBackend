using AutomeetBackend.Services;
using AutomeetBackend.Repositories;
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

            return user.Subscription;
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
            // if (await _userService.TryUpdateUserSubscriptionAsync(userEmail, subscription))
            // {
            //     return Accepted();
            // }
            // else
            // {
            //     return NotFound();
            // }
        }

    }
}
