

namespace Marketplace.Dal.Repositories
{
    using System.Threading.Tasks;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public UserRepository()
        {
            this.context = new MarketplaceContext();
        }
        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<User[]> GetAllUsersAsync()
        {
            return await this.context.Users.ToArrayAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await this.context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetUserByNameAsync(string username)
        {
            return await this.context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User> DeleteUserByIdAsync(int id)
        {
            //validation: check if the auth user matches the user id and/or if the user has 'admin privileges'
            var result = await this.context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(result != null)
            {
                this.context.Users.Remove(result);
                await this.context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<User> CreateUserAsync(string name)
        {
            //validation: ratelimiting would be a good idea here
            //passwords: can be validated, checked and handled here as well
            User user = new() { Username = name };
            var result = await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<User> UpdateUserByIdAsync(int id, string name)
        {
            //validation: check if the auth user matches the user id and/or if the user has 'admin privileges'
            var result = await this.context.Users.FirstOrDefaultAsync(u => u.Id == id);
            result.Username = name;

            if (result != null)
            {
                this.context.Users.Update(result);
                await this.context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        #endregion
    }
}