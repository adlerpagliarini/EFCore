using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.Domain.Developers;
using EFCore.Domain.Tasks;

namespace EFCore.Infrastructure.Mappings
{
    public class TaskToDoMap : IEntityTypeConfiguration<TaskToDo>
    {
        public void Configure(EntityTypeBuilder<TaskToDo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.DeadLine).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder.HasOne<Developer>().WithMany(e => e.TasksToDo).HasForeignKey(k => k.DeveloperId);
        }
    }
}
