using Microsoft.AspNetCore.Mvc;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbAdapterController : ControllerBase
    {
        private readonly UserService _userService;

        public DbAdapterController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPut("{userEmail}")]
        public async Task<ActionResult<User>> UpdateUserDb(
                string userEmail,
                [FromBody]
                DbAdapter dbAdapter
            )
        {
            System.Console.WriteLine("here");
            if (await _userService.UpdateUserDbAsync(userEmail, dbAdapter))
            {
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{userEmail}")]
        public async Task<ActionResult> DeleteUserDbAdapter(string userEmail)
        {
            if (await _userService.DeleteUserDbAsync(userEmail))
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
