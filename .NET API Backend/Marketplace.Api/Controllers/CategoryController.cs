

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
    public class CategoryController : ControllerBase
    {
        #region Fields

        private readonly ILogger<UserController> logger;

        private readonly ICategoryBl categoryBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userBl">The user business logic.</param>
        public CategoryController(ILogger<UserController> logger, ICategoryBl categoryBl)
        {
            this.logger = logger;
            this.categoryBl = categoryBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [Route("category/")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            IEnumerable<Category> result;

            try
            {
                result = await this.categoryBl.GetCategoriesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpGet]
        [Route("category/{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {

            Category result;

            try
            {
                result = await this.categoryBl.GetCategoryByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpDelete]
        [Route("category/{id}")]
        public async Task<ActionResult<Category>> DeleteCategoryById(int id)
        {
            Category result;
            try
            {
                result = await this.categoryBl.DeleteCategoryByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPost]
        [Route("category/{name}")]
        public async Task<ActionResult<User>> CreateCategory(string name)
        {
            Category result;

            try
            {
                result = await this.categoryBl.CreateCategoryAsync(name).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPut]
        [Route("category/{id}/{name}")]
        public async Task<ActionResult<Category>> UpdateCategoryById(int id, string name)
        {
            Category result;

            try
            {
                result = await this.categoryBl.UpdateCategoryByIdAsync(id, name).ConfigureAwait(false);
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