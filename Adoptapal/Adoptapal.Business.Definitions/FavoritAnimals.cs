/*
 * File: FavoritAnimals.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file defines the "FavoritAnimals" entity class, representing associations between users
 * and their favorite animals, with properties for the unique identifier, user, and animal.
 * 
 */

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents associations between users and their favorite animals.
    /// </summary>
    public class FavoritAnimals
    {
        /// <summary>
        /// Gets or sets the unique identifier for the favorit animals association.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the favorite animals.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the animal that is favorited by the user.
        /// </summary>
        public Animal? Animal { get; set; }
    }
}
