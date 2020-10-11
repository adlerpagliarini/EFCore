using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.Domain.Developers;

namespace EFCore.Infrastructure.Mappings
{
    public class BackEndDeveloperMap : IEntityTypeConfiguration<BackEndDeveloper>
    {
        public void Configure(EntityTypeBuilder<BackEndDeveloper> builder)
        {
            // builder.ToTable(nameof(BackEndDeveloper));
        }
    }
}
