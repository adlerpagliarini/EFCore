using EFCore.Domain.Entity;
using FluentValidation;
using System.Collections.ObjectModel;

namespace EFCore.Domain.Tasks
{
    public class Skill : Identity<Skill, long>
    {
        public Skill(string title)
        {
            Title = title;
            TasksToDo = new Collection<SkillTaskToDo>();
        }

        protected Skill() { }

        public string Title { get; protected set; }

        public virtual Collection<SkillTaskToDo> TasksToDo { get; protected set; }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.Title).NotEmpty();
            return Validator.Validate(this).IsValid;
        }
    }
}
