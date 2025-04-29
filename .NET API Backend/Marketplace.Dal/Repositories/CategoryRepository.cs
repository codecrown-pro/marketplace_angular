

namespace Marketplace.Dal.Repositories
{
    using System.Threading.Tasks;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;
    using Microsoft.EntityFrameworkCore;

    public class CategoryRepository : ICategoryRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public CategoryRepository()
        {
            this.context = new MarketplaceContext();
        }
        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<Category[]> GetAllCategoriesAsync()
        {
            return await this.context.Categories.ToArrayAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await this.context.Categories.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Category> DeleteCategoryByIdAsync(int id)
        {
            //validation: check if the auth user has 'admin privileges'
            var result = await this.context.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (result != null)
            {
                this.context.Categories.Remove(result);
                await this.context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Category> CreateCategoryAsync(string name)
        {
            //validation: check if the auth user has 'admin privileges'
            Category Category = new() { Name = name };
            var result = await this.context.Categories.AddAsync(Category);
            await this.context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Category> UpdateCategoryByIdAsync(int id, string name)
        {
            //validation: check if the auth user has 'admin privileges'
            var result = await this.context.Categories.FirstOrDefaultAsync(u => u.Id == id);
            result.Name = name;

            if (result != null)
            {
                this.context.Categories.Update(result);
                await this.context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        #endregion
    }
}