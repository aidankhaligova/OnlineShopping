using Microsoft.AspNetCore.Identity;
using OnlineShopping.Core.Domains.Abstract;
using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Identity
{
    public class UserStore : IUserStore<User>,IUserRoleStore<User>,IUserPasswordStore<User>
    {
        private readonly IUnitOfWork Db;
        public UserStore(IUnitOfWork db)
        {
            Db = db;
        }
        #region Userstore
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //hecne yoxdu
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(userId);

            User user = Db.UserRepository.Get(id);

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            User user = Db.UserRepository.Get(normalizedUserName);

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IUserRoleStore
        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            IList<string> roles = user.UserRoles.Select(x => x.Role.Name).ToList();

            return Task.FromResult(roles);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region  IUserPasswordStore
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
