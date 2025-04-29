

namespace Marketplace.Core.Dal
{
    using System.Threading.Tasks;
    using Marketplace.Core.Model;
    using System;

    /// <summary>
    /// Contract for the Offer data access
    /// </summary>
    public interface IOfferRepository
    {
        #region Methods

        /// <summary>
        /// Gets all Offers asynchronous.
        /// </summary>
        /// <returns>Array of Offers</returns>
        Task<Offer[]> GetAllOffersAsync();
        Task<Offer> GetOfferByIdAsync(Guid id);
        Task<Offer> DeleteOfferByIdAsync(Guid id);
        Task<Offer> CreateOfferAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId);
        Task<Offer> UpdateOfferByIdAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId, Guid id);
        #endregion
    }
}