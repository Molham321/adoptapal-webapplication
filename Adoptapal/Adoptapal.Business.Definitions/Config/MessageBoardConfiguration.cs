
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
        }
    }
}
