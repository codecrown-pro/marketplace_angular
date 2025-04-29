

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
    /// Services for Offers
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class OfferController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OfferController> logger;

        private readonly IOfferBl offerBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="offerBl">The Offer business logic.</param>
        public OfferController(ILogger<OfferController> logger, IOfferBl offerBl)
        {
            this.logger = logger;
            this.offerBl = offerBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of Offers.
        /// </summary>
        /// <returns>List of Offers</returns>
        [HttpGet]
        [Route("offer/")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            IEnumerable<Offer> result;
            
            try
            {
                Console.WriteLine("made it");
                result = await this.offerBl.GetOffersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpGet]
        [Route("offer/{id}")]
        public async Task<ActionResult<Offer>> GetOfferById(Guid id)
        {

            Offer result;

            try
            {
                result = await this.offerBl.GetOfferByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpDelete]
        [Route("offer/{id}")]
        public async Task<ActionResult<Offer>> DeleteOfferById(Guid id)
        {
            Offer result;
            try
            {
                result = await this.offerBl.DeleteOfferByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPost]
        [Route("offer/{categoryId}/{description}/{location}/{pictureUrl}/{title}/{userId}")]
        public async Task<ActionResult<Offer>> CreateOffer(int categoryId, string description, string location, string pictureUrl, string title, int userId)
        {
            Offer result;

            try
            {
                result = await this.offerBl.CreateOfferAsync(categoryId, description, location, pictureUrl, title, userId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPut]
        [Route("offer/{categoryId}/{description}/{location}/{pictureUrl}/{title}/{userId}/{id}")]
        public async Task<ActionResult<Offer>> UpdateOfferById(int categoryId, string description, string location, string pictureUrl, string title, int userId, Guid id)
        {
            Offer result;

            try
            {
                result = await this.offerBl.UpdateOfferByIdAsync(categoryId, description, location, pictureUrl, title, userId, id).ConfigureAwait(false);
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