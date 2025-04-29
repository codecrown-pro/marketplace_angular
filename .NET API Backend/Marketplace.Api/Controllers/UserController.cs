

namespace Marketplace.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Services for Users
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly ILogger<UserController> logger;

        private readonly IUserBl userBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userBl">The user business logic.</param>
        public UserController(ILogger<UserController> logger, IUserBl userBl)
        {
            this.logger = logger;
            this.userBl = userBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [Route("user/")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            IEnumerable<User> result;

            try
            {
                result = await this.userBl.GetUsersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {

            User result;

            try
            {
                result = await this.userBl.GetUserByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpGet]
        [Route("user/name/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string username)
        {

            User result;

            try
            {
                result = await this.userBl.GetUserByNameAsync(username).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpDelete]
        [Route("user/{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            User result;
            try
            {
                result = await this.userBl.DeleteUserByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPost]
        [Route("user/{name}")]
        public async Task<ActionResult<User>> CreateUser(string name)
        {
            User result;

            try
            {
                result = await this.userBl.CreateUserAsync(name).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPut]
        [Route("user/{id}/{name}")]
        public async Task<ActionResult<User>> UpdateUserById(int id, string name)
        {
            User result;

            try
            {
                result = await this.userBl.UpdateUserByIdAsync(id, name).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }


        #endregion
    }
}