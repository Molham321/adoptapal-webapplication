/*
 * File: Address.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file defines the "Address" entity class, representing location information
 * with properties such as street, street number, city, zip code, longitude, and latitude.
 * 
 */

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents location information.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the unique identifier for the address.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Gets or sets the street number.
        /// </summary>
        public string? StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the ZIP or postal code.
        /// </summary>
        public string? Zip { get; set; }

        /// <summary>
        /// Gets or sets the longitude coordinate.
        /// </summary>
        public double? Long { get; set; }

        /// <summary>
        /// Gets or sets the latitude coordinate.
        /// </summary>
        public double? Lat { get; set; }
    }
}
