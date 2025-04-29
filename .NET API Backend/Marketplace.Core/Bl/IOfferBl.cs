

namespace Marketplace.Core.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the Offer logic
    /// </summary>
    public interface IOfferBl
    {
        #region Methods

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        /// <returns>LIst of Offers</returns>
        Task<IEnumerable<Offer>> GetOffersAsync();
        Task<Offer> GetOfferByIdAsync(Guid id);
        Task<Offer> DeleteOfferByIdAsync(Guid id);
        Task<Offer> CreateOfferAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId);
        Task<Offer> UpdateOfferByIdAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId, Guid id);
        #endregion
    }
}