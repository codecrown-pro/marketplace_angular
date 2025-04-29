

namespace Marketplace.Core.Model
{
    using System.Collections.Generic;

    public class Category
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public byte Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the offers.
        /// </summary>
        /// <value>
        /// The offers.
        /// </value>
        public List<Offer> Offers { get; set; }

        #endregion
    }
}