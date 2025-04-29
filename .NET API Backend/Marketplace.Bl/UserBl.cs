

namespace Marketplace.Bl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;

    /// <summary>
    /// Users' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.IUserBl" />
    public class UserBl : IUserBl
    {
        #region Fields

        private readonly IUserRepository userRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBl"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserBl(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await this.userRepository.GetAllUsersAsync().ConfigureAwait(false);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await this.userRepository.GetUserByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<User> GetUserByNameAsync(string username)
        {
            return await this.userRepository.GetUserByNameAsync(username).ConfigureAwait(false);
        }
        public async Task<User> DeleteUserByIdAsync(int id)
        {
            return await this.userRepository.DeleteUserByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<User> CreateUserAsync(string name)
        {
            return await this.userRepository.CreateUserAsync(name).ConfigureAwait(false);
        }
        public async Task<User> UpdateUserByIdAsync(int id, string name)
        {
            return await this.userRepository.UpdateUserByIdAsync(id, name).ConfigureAwait(false);
        }
        #endregion
    }
}