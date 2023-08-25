/*
 * File: AnimalConfiguration.cs
 * Namespace: Adoptapal.Business.Definitions.Config
 * 
 * Description:
 * This file contains the Entity Framework Core configuration for the "Animal" entity,
 * defining how the entity's properties and relationships are mapped to the database.
 * 
 * Author: [Your Name]
 * Date: [Date]
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adoptapal.Business.Definitions.Config
{
    /// <summary>
    /// Configures the mapping for the Animal entity.
    /// </summary>
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        /// <summary>
        /// Configures the properties and relationships of the Animal entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            // Maps the entity to the "Tiere" table in the database.
            builder.ToTable("Tiere");

            // Configures the relationship between Animal and User entities.
            builder.HasOne(animal => animal.User)           // Animal has one User.
                   .WithMany()                             // User can have multiple related Animals.
                   .IsRequired(false);                     // The relationship is optional.
        }
    }
}
