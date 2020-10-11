using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.Domain.Developers;

namespace EFCore.Infrastructure.Mappings
{
    public class FullStackDeveloperMap : IEntityTypeConfiguration<FullStackDeveloper>
    {
        public void Configure(EntityTypeBuilder<FullStackDeveloper> builder)
        {
            builder.OwnsOne(e => e.ExtraMotivation).Property(e => e.Factor).HasColumnType("varchar(50)");
            // builder.ToTable(nameof(FullStackDeveloper));
        }
    }
}
