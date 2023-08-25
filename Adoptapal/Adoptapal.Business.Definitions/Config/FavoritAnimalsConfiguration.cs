/*
 * File: FavoritAnimalsConfiguration.cs
 * Namespace: Adoptapal.Business.Definitions.Config
 * 
 * Description:
 * This file contains the Entity Framework Core configuration for the "FavoritAnimals" entity,
 * defining how the entity's properties and relationships are mapped to the database.
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adoptapal.Business.Definitions.Config
{
    /// <summary>
    /// Configures the mapping for the FavoritAnimals entity.
    /// </summary>
    public class FavoritAnimalsConfiguration : IEntityTypeConfiguration<FavoritAnimals>
    {
        /// <summary>
        /// Configures the properties and relationships of the FavoritAnimals entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<FavoritAnimals> builder)
        {
            // Maps the entity to the "Lieblingstiere" table in the database.
            builder.ToTable("Lieblingstiere");

            // Configures the relationship between FavoritAnimals and User entities.
            builder.HasOne(favoritAnimals => favoritAnimals.User)  // FavoritAnimals has one User.
                   .WithMany()                                    // User can have multiple related FavoritAnimals.
                   .IsRequired(false);                            // The relationship is optional.

            // Configures the relationship between FavoritAnimals and Animal entities.
            builder.HasOne(favoritAnimals => favoritAnimals.Animal)  // FavoritAnimals has one Animal.
                   .WithMany()                                     // Animal can have multiple related FavoritAnimals.
                   .IsRequired(false);                             // The relationship is optional.
        }
    }
}
