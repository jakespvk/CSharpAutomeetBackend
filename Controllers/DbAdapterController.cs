using Microsoft.AspNetCore.Mvc;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbAdapterController : ControllerBase
    {
        private readonly UserService _userService;

        public DbAdapterController(UserService userService, DbAdapterService? dbService)
        {
            _userService = userService;
        }

        [HttpPut("{userEmail}")]
        public async Task<ActionResult<List<string>?>> UpdateUserDb(
                string userEmail,
                [FromBody]
                DbAdapter dbAdapter
            )
        {
            await dbAdapter.getColumns();
            if (dbAdapter.Columns is not null)
            {
                if (await _userService.UpdateUserDbAsync(
                            userEmail,
                            dbAdapter,
                            dbAdapter.Columns
                        )
                    )
                {
                    {
                        return dbAdapter.Columns;
                    }
                }
                return NotFound();
            }
            return BadRequest("There was an issue retrieving data from your db api");
        }

        [HttpPut("{userEmail}/active-columns")]
        public async Task<ActionResult<List<string>>> UpdateUserActiveColumns(
                string userEmail,
                [FromBody]
                List<string> activeColumns
            )
        {
            User? user = await _userService.GetUserAsync(userEmail);
            if (user is User)
            {
                if (user.DbAdapter is DbAdapter)
                {
                    user.DbAdapter.ActiveColumns = activeColumns;
                    return user.DbAdapter.ActiveColumns;
                }
                return BadRequest("No Db Provider set");
            }
            return NotFound();
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
