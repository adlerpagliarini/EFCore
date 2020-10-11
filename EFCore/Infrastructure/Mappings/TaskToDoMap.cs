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
            builder.HasMany(e => e.Skills).WithMany(e => e.TasksToDo)
                .UsingEntity<SkillTaskToDo>(
                    right => right.HasOne(e => e.Skill).WithMany().HasForeignKey(e => e.SkillsId),
                    left => left.HasOne(e => e.TaskToDo).WithMany().HasForeignKey(e => e.TasksToDoId));
        }
    }
}
