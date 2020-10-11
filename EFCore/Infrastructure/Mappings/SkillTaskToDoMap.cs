using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.Domain.Tasks;

namespace EFCore.Infrastructure.Mappings
{
    public class SkillTaskToDoMap : IEntityTypeConfiguration<SkillTaskToDo>
    {
        public void Configure(EntityTypeBuilder<SkillTaskToDo> builder)
        {
            builder.HasKey(e => new { e.SkillsId, e.TasksToDoId });
            builder.HasOne(e => e.TaskToDo).WithMany(e => e.Skills).HasForeignKey(e => e.TasksToDoId);
            builder.HasOne(e => e.Skill).WithMany(e => e.TasksToDo).HasForeignKey(e => e.SkillsId);
        }
    }
}
