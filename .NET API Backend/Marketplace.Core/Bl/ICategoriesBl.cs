

namespace Marketplace.Core.Bl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the Category logic
    /// </summary>
    public interface ICategoryBl
    {
        #region Methods

        /// <summary>
        /// Gets the Categorys.
        /// </summary>
        /// <returns>LIst of Categorys</returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> DeleteCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(string name);
        Task<Category> UpdateCategoryByIdAsync(int id, string name);
        #endregion
    }
}