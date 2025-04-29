

namespace Marketplace.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;

    /// <summary>
    /// Offers' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.IOfferBl" />
    public class OfferBl : IOfferBl
    {
        #region Fields

        private readonly IOfferRepository offerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferBl"/> class.
        /// </summary>
        /// <param name="OfferRepository">The Offer repository.</param>
        public OfferBl(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await this.offerRepository.GetAllOffersAsync().ConfigureAwait(false);
        }
        public async Task<Offer> GetOfferByIdAsync(Guid id)
        {
            return await this.offerRepository.GetOfferByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<Offer> DeleteOfferByIdAsync(Guid id)
        {
            return await this.offerRepository.DeleteOfferByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<Offer> CreateOfferAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId)
        {
            return await this.offerRepository.CreateOfferAsync(categoryId, description, location, pictureUrl, title, userId).ConfigureAwait(false);
        }
        public async Task<Offer> UpdateOfferByIdAsync(int categoryId, string description, string location, string pictureUrl, string title, int userId, Guid id)
        {
            return await this.offerRepository.UpdateOfferByIdAsync(categoryId, description, location, pictureUrl, title, userId, id).ConfigureAwait(false);
        }
        #endregion
    }
}