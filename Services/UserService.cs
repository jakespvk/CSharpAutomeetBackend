using AutomeetBackend.Models;
using AutomeetBackend.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AutomeetBackend.Services
{
    public sealed class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<User> TryGetUserAsync(string email)
        {
            return await _repository.GetUserAsync(email);
            // User user;
            //
            // try
            // {
            //     user = await _repository.GetUserAsync(email);
            // }
            // catch (Exception err)
            // {
            //     Console.WriteLine("err:", err.Message);
            //     throw;
            // }
            //
            // return user;
        }

        public async Task<User> TryCreateUserAsync(string email)
        {
            return await _repository.CreateUserAsync(email);
            // User user;
            //
            // try
            // {
            //     user = await _repository.CreateUserAsync(email);
            // }
            // catch (Exception err)
            // {
            //     Console.WriteLine("err:", err.Message);
            //     throw;
            // }
            //
            // return user;
        }

        public async Task TryUpdateUserSubscriptionAsync(
        // public async Task<bool> TryUpdateUserSubscriptionAsync(
                string email,
                Subscription subscription
            )
        {
            User user = await _repository.GetUserAsync(email);
            user.Subscription = subscription;
            await _repository.UpdateUserAsync(user);
            // User user;
            //
            // try
            // {
            //     user = await _repository.GetUserAsync(email);
            // }
            // catch (Exception err)
            // {
            //     Console.WriteLine("err:", err.Message);
            //     return false;
            // }
            //
            // user.Subscription = subscription;
            //
            // try
            // {
            //     await _repository.UpdateUserAsync(user);
            // }
            // catch (System.NullReferenceException err)
            // {
            //     System.Console.WriteLine("err:", err.Message);
            //     return false;
            // }
            //
            // return true;
        }

        public async Task TryUpdateUserDbAsync(
        // public async Task<bool> TryUpdateUserDbAsync(
                string email,
                DbAdapter dbAdapter,
                List<string>? columns = null,
                List<string>? activeColumns = null
            )
        {
            User user = await _repository.GetUserAsync(email);
            user.DbAdapter = dbAdapter;

            if (columns != null)
            {
                user.DbAdapter.Columns = columns;
            }

            if (activeColumns != null)
            {
                user.DbAdapter.ActiveColumns = columns;
            }

            await _repository.UpdateUserAsync(user);

            // User user;
            //
            // try
            // {
            //     user = await _repository.GetUserAsync(email);
            // }
            // catch (System.NullReferenceException err)
            // {
            //     // handle this error
            //     Console.WriteLine("error: " + err.Message);
            //     throw;
            // }
            //
            // user.DbAdapter = dbAdapter;
            //
            // if (columns != null)
            // {
            //     user.DbAdapter.Columns = columns;
            // }
            //
            // if (activeColumns != null)
            // {
            //     user.DbAdapter.ActiveColumns = activeColumns;
            // }
            //
            // try
            // {
            //     await _repository.UpdateUserAsync(user);
            // }
            // catch (System.NullReferenceException err)
            // {
            //     System.Console.WriteLine("err:", err.Message);
            //     return false;
            // }
            //
            // return true;
        }

        public async Task TryDeleteUserDbAsync(
        // public async Task<bool> TryDeleteUserDbAsync(
                string email
            )
        {
            User user = await _repository.GetUserAsync(email);
            user.DbAdapter = null;
            await _repository.UpdateUserAsync(user);
            // User user;
            //
            // try
            // {
            //     user = await _repository.GetUserAsync(email);
            //     user.DbAdapter = null;
            //     await _repository.UpdateUserAsync(user);
            // }
            // catch (Exception err)
            // {
            //     Console.WriteLine("err:", err.Message);
            //     return false;
            // }
            //
            // return true;
        }
    }
}
