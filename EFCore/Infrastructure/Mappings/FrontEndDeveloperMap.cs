using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.Domain.Developers;

namespace EFCore.Infrastructure.Mappings
{
    public class FrontEndDeveloperMap : IEntityTypeConfiguration<FrontEndDeveloper>
    {
        public void Configure(EntityTypeBuilder<FrontEndDeveloper> builder)
        {
            // builder.ToTable(nameof(FrontEndDeveloper));
        }
    }
}
