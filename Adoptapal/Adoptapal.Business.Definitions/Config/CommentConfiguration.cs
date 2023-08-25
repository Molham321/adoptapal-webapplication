/*
 * File: CommentConfiguration.cs
 * Namespace: Adoptapal.Business.Definitions.Config
 * 
 * Description:
 * This file contains the Entity Framework Core configuration for the "Comment" entity,
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
    /// Configures the mapping for the Comment entity.
    /// </summary>
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        /// <summary>
        /// Configures the properties and relationships of the Comment entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Maps the entity to the "Kommentare" table in the database.
            builder.ToTable("Kommentare");

            // Configures the relationship between Comment and Post entities.
            builder.HasOne(comment => comment.Post)         // Comment has one Post.
                   .WithMany()                             // Post can have multiple related Comments.
                   .IsRequired(false);                     // The relationship is optional.

            // Configures the relationship between Comment and User entities.
            builder.HasOne(comment => comment.User)         // Comment has one User.
                   .WithMany()                             // User can have multiple related Comments.
                   .IsRequired(false);                     // The relationship is optional.
        }
    }
}
