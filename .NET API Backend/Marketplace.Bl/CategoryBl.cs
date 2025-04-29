

namespace Marketplace.Bl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;

    /// <summary>
    /// Categorys' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.ICategoryBl" />
    public class CategoryBl : ICategoryBl
    {
        #region Fields

        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryBl"/> class.
        /// </summary>
        /// <param name="categoryRepository">The Category repository.</param>
        public CategoryBl(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await this.categoryRepository.GetAllCategoriesAsync().ConfigureAwait(false);
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await this.categoryRepository.GetCategoryByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<Category> DeleteCategoryByIdAsync(int id)
        {
            return await this.categoryRepository.DeleteCategoryByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<Category> CreateCategoryAsync(string name)
        {
            return await this.categoryRepository.CreateCategoryAsync(name).ConfigureAwait(false);
        }
        public async Task<Category> UpdateCategoryByIdAsync(int id, string name)
        {
            return await this.categoryRepository.UpdateCategoryByIdAsync(id, name).ConfigureAwait(false);
        }
        #endregion
    }
}