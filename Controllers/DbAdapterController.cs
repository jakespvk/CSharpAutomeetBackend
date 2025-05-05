using AutomeetBackend.Models;
using AutomeetBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AutomeetBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbAdapterController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly DbAdapterService? _dbService;

        public DbAdapterController(
                UserService userService,
                DbAdapterService? dbService
            )
        {
            _userService = userService;

            if (dbService != null)
            {
                _dbService = dbService;
            }
        }

        // "well...... there are a lot of things to think about here" -Kostya
        // definitely, split it to two methods, one init UserDbAdapter
        // other one, updateDbAdapter
        // in both cases maybe we can maybe we don't 
        // pass the responsibility of providing the whole already populated
        // dbAdapter by the user of the API
        [HttpPut("{userEmail}")]
        public async Task<ActionResult<List<string>?>> InitializeUserDbAdapter(
                string userEmail,
                [FromBody]
                DbAdapter dbAdapter
            // this returns the creds for user db adapter API so I can
            // go get the columns
            )
        {
            await dbAdapter.getColumns();
            if (dbAdapter.Columns is not null)
            {
                try
                {
                    await _userService.TryUpdateUserDbAsync(
                                userEmail,
                                dbAdapter,
                                dbAdapter.Columns
                            );

                    {
                        return dbAdapter.Columns;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("err:", err.Message);
                    return NotFound();
                }
            }
            return BadRequest("There was an issue retrieving data from your db api");
        }

        [HttpPut("{userEmail}/active-columns")]
        public async Task<ActionResult> UpdateUserActiveColumns(
                string userEmail,
                [FromBody]
                List<string> activeColumns
            )
        {
            try
            {
                User user = await _userService.TryGetUserAsync(userEmail);
                if (user.DbAdapter == null)
                {
                    return BadRequest("User does not have a DbAdapter defined");
                }
                else
                {
                    await _userService.TryUpdateUserDbAsync(
                            userEmail,
                            user.DbAdapter,
                            activeColumns: activeColumns
                        );
                    return Ok();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("err:", err.Message);
                return BadRequest("User not found");
            }
        }

        [HttpDelete("{userEmail}")]
        public async Task<ActionResult> DeleteUserDbAdapter(string userEmail)
        {
            try
            {
                await _userService.TryDeleteUserDbAsync(userEmail);
                return Accepted();
            }
            catch (Exception err)
            {
                Console.WriteLine("err:", err.Message);
                return NotFound();
            }
        }
    }
}
