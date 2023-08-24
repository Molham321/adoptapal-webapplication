using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adoptapal.Business.Definitions.Config
{
    public class FavoritAnimalsConfiguration: IEntityTypeConfiguration<FavoritAnimals>
    {
        public void Configure(EntityTypeBuilder<FavoritAnimals> builder)
        {
            builder.ToTable("Lieblingstiere");
            builder.HasOne(it => it.User).WithMany().IsRequired(false);
            builder.HasOne(it => it.Animal).WithMany().IsRequired(false);
        }
    }
}
