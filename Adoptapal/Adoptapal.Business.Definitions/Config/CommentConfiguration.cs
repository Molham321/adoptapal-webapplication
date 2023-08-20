using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adoptapal.Business.Definitions.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder) 
        {
            builder.ToTable("Kommentare");
            builder.HasOne(it => it.Post).WithMany().IsRequired(false);
            builder.HasOne(it => it.User).WithMany().IsRequired(false);
        }
    }
}
