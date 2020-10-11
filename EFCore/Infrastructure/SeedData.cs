using EFCore.Domain.Developers;
using EFCore.Domain.Enums;
using EFCore.Domain.Motivations;
using EFCore.Domain.Tasks;
using EFCore.Domain.ValueObjects;
using System;
using System.Linq;

namespace EFCore.Infrastructure
{
    public static class SeedData
    {
        public static void SeedDatabase(DatabaseContext context)
        {
            try
            {
                if (context.Developer.Any()) return;

                var motivation_frontend = new Motivation("User Experience", null);
                var motivation_backend = new Motivation("System Integration", null);
                var motivation_fullstack = new Motivation("Connect Front and Back", null);

                var skill_backend_1 = new Skill("C#");
                var skill_backend_2 = new Skill("Database");
                var skill_frontend_1 = new Skill("Html");

                var frontendTask = new TaskToDo("Dev HTML page", DateTime.Now, DateTime.Now.AddDays(15), false, null);
                frontendTask.SetSkill(skill_frontend_1);

                var backendTask = new TaskToDo("Dev CSharp code", DateTime.Now, DateTime.Now.AddDays(15), false, null);
                backendTask.SetSkill(skill_backend_1);
                backendTask.SetSkill(skill_backend_2);   
                

                var code1 = new DevCode("#123");
                var code2 = new DevCode("#321");
                var code3 = new DevCode("#999");

                var frontend = new FrontEndDeveloper(code1, "Adler Pagliarini", DevType.FrontEnd, true, "React");
                frontend.AddItemToDo(frontendTask);
                frontend.SetMotivation(motivation_frontend);


                var backend = new BackEndDeveloper(code2, "Pagliarini Nascimento", DevType.BackEnd, true, "Postgre");
                backend.AddItemToDo(backendTask);
                backend.SetMotivation(motivation_backend);


                var fullstack = new FullStackDeveloper(code3, "Adler Nascimento", DevType.Fullstack, "AWS");
                fullstack.AddItemToDo(frontendTask);
                fullstack.AddItemToDo(backendTask);
                fullstack.SetMotivation(motivation_fullstack);

                var extra_motivation = new ExtraMotivation("Coffee");
                fullstack.SetMotivation(extra_motivation);

                context.FrontEndDeveloper.Add(frontend);
                context.BackEndDeveloper.Add(backend);
                context.FullStackDeveloper.Add(fullstack);               

                var onTrack = context.ChangeTracker.Entries().ToList();
                foreach (var item in onTrack)                
                    Console.WriteLine($"Is on Track: {item.Entity.GetType().Name}");

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        }

    }
}
