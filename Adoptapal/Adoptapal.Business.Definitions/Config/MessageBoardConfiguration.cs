/*
 * File: MessageBoardConfiguration.cs
 * Namespace: Adoptapal.Business.Definitions.Config
 * 
 * Description:
 * This file contains the Entity Framework Core configuration for the "MessageBoard" entity,
 * defining how the entity's properties and relationships are mapped to the database.
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adoptapal.Business.Definitions.Config
{
    /// <summary>
    /// Configures the mapping for the MessageBoard entity.
    /// </summary>
    public class MessageBoardConfiguration : IEntityTypeConfiguration<MessageBoard>
    {
        /// <summary>
        /// Configures the properties and relationships of the MessageBoard entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<MessageBoard> builder)
        {
            // Maps the entity to the "Post" table in the database.
            builder.ToTable("Post");

            // Configures the relationship between MessageBoard and User entities.
            builder.HasOne(messageBoard => messageBoard.User) // MessageBoard has one User.
                   .WithMany()                                 // User can have multiple related MessageBoards.
                   .IsRequired(false);                         // The relationship is optional.
        }
    }
}
