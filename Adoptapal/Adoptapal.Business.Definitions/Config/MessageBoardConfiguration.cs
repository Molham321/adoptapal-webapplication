
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Adoptapal.Business.Definitions.Config
{
    public class MessageBoardConfiguration : IEntityTypeConfiguration<MessageBoard>
    {
        public void Configure(EntityTypeBuilder<MessageBoard> builder)
        {
            builder.ToTable("Post");
            builder.HasOne(it => it.User).WithMany().IsRequired(false);
            // builder.HasOne(it => it.Comments).WithMany().IsRequired(false);
            //builder.HasMany(it => it.Comments).WithOne(it => it.Post).HasForeignKey(it => it.Id);
        }
    }
}
