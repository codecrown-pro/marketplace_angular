

namespace Marketplace.Core.Bl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the User logic
    /// </summary>
    public interface IUserBl
    {
        #region Methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>LIst of users</returns>
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string name);
        Task<User> DeleteUserByIdAsync(int id);
        Task<User> CreateUserAsync(string user);
        Task<User> UpdateUserByIdAsync(int id, string name);
        #endregion
    }
}