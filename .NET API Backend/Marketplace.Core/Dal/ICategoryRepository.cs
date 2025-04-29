

namespace Marketplace.Core.Dal
{
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the Category data access
    /// </summary>
    public interface ICategoryRepository
    {
        #region Methods

        /// <summary>
        /// Gets all Categorys asynchronous.
        /// </summary>
        /// <returns>Array of Categorys</returns>
        Task<Category[]> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> DeleteCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(string name);
        Task<Category> UpdateCategoryByIdAsync(int id, string name);
        #endregion
    }
}