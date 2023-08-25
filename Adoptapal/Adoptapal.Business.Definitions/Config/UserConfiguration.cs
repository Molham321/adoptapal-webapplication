/*
 * File: UserConfiguration.cs
 * Namespace: Adoptapal.Business.Definitions.Config
 * 
 * Description:
 * This file contains the Entity Framework Core configuration for the "User" entity,
 * defining how the entity's properties and relationships are mapped to the database.
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adoptapal.Business.Definitions.Config
{
    /// <summary>
    /// Configures the mapping for the User entity.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the properties and relationships of the User entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Maps the entity to the "Nutzer" table in the database.
            builder.ToTable("Nutzer");

            // Configures the relationship between User and Address entities.
            builder.HasOne(user => user.Address) // User has one Address.
                   .WithMany()                   // Address can have multiple related Users.
                   .IsRequired(false);           // The relationship is optional.
        }
    }
}
