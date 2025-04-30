using AutomeetBackend.Models;
using AutomeetBackend.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AutomeetBackend.Services
{
    public sealed class UserService
    {
        private readonly UserRepository _repository;

        // shouldn't know about the db
        public UserService(UserRepository userRepository)
        {
            _repository = userRepository;
        }

        // "this method smells" -Kostya
        // promises to update user sub
        // some mysterious reason can return false
        // should be "TryUpdateUserSubscriptionAsync"
        public async Task<bool> TryUpdateUserSubscriptionAsync(
                string email,
                Subscription subscription
            )
        {
            User? user = await _repository.GetUserAsync(email);

            // gray area - maybe belong in UserRepository, maybe not
            // keep in service, kind of business logic
            if (user == null)
            {
                return false;
            }

            user.Subscription = subscription;
            await _repository.SaveChangesAsync();
            return true;
        }

        // keep in service, kind of business logic
        public async Task<bool> TryUpdateUserDbAsync(
                string email,
                DbAdapter dbAdapter,
                List<string>? columns = null,
                List<string>? activeColumns = null
            )
        {
            User? user = await _repository.GetUserAsync(email);
            if (user == null)
            {
                return false;
            }

            user.DbAdapter = dbAdapter;

            if (columns != null)
            {
                user.DbAdapter.Columns = columns;
            }

            if (activeColumns != null)
            {
                user.DbAdapter.ActiveColumns = activeColumns;
            }

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryDeleteUserDbAsync(
                string email
            )
        {
            User? user = await _repository.GetUserAsync(email);

            if (user == null)
            {
                return false;
            }

            user.DbAdapter = null;

            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
