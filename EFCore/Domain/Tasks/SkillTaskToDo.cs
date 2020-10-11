namespace EFCore.Domain.Tasks
{
    public class SkillTaskToDo
    {
        public SkillTaskToDo(Skill skill, TaskToDo taskToDo)
        {
            Skill = skill;
            TaskToDo = taskToDo;
        }

        protected SkillTaskToDo() { }

        public long SkillsId { get; protected set; }
        public long TasksToDoId { get; protected set; }
        public virtual Skill Skill { get; protected set; }
        public virtual TaskToDo TaskToDo { get; protected set; }
    }
}
