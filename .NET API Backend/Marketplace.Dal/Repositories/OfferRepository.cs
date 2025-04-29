

namespace Marketplace.Dal.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;
    using Microsoft.EntityFrameworkCore;

    public class OfferRepository : IOfferRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public OfferRepository()
        {
            this.context = new MarketplaceContext();
        }
        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<Offer[]> GetAllOffersAsync()
        {
            return await this.context.Offers.ToArrayAsync();
        }
        public async Task<Offer> GetOfferByIdAsync(Guid id)
        {
            return await this.context.Offers.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Offer> DeleteOfferByIdAsync(Guid id)
        {
            //validation: check if username matches that of the offer's author, if not the same => return null
            var result = await this.context.Offers.FirstOrDefaultAsync(u => u.Id == id);
            if (result != null)
            {
                this.context.Offers.Remove(result);
                await this.context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Offer> CreateOfferAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId)
        {
            
            if (userId == 0) return null; //validation: we can further rewrite the implemented controllers to account for null and null checking

            Offer Offer = new() { CategoryId = (byte)categoryId, Description = description, Location = location, PictureUrl = pictureUrl, Title=title, UserId = userId, PublishedOn = DateTime.Now};

            var result = await this.context.Offers.AddAsync(Offer);
            await this.context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Offer> UpdateOfferByIdAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId, Guid id)
        {
            var result = await this.context.Offers.FirstOrDefaultAsync(u => u.Id == id);

            //validation: check if username matches that of the offer's author, if not the same => return null

            if (result.UserId != userId) return null;

            result.CategoryId = (byte)categoryId;
            result.Description = description;
            result.Location = location;
            result.PictureUrl = pictureUrl;
            result.Title = title;

            var final = await this.context.Offers.AddAsync(result);
            await this.context.SaveChangesAsync();
            return final.Entity;
        }
        #endregion
    }
}