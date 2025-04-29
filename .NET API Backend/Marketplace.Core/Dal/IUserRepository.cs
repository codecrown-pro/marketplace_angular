

namespace Marketplace.Core.Dal
{
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the User data access
    /// </summary>
    public interface IUserRepository
    {
        #region Methods

        /// <summary>
        /// Gets all users asynchronous.
        /// </summary>
        /// <returns>Array of users</returns>
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string username);
        Task<User> DeleteUserByIdAsync(int id);
        Task<User> CreateUserAsync(string name);
        Task<User> UpdateUserByIdAsync(int id, string name);
        #endregion
    }
}