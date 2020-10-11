using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using EFCore.Infrastructure.Mappings;
using System.IO;
using EFCore.Domain.Developers;
using EFCore.Infrastructure.Interceptors;
using EFCore.Domain.Tasks;

namespace EFCore.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Developer> Developer { get; set; }
        public DbSet<FullStackDeveloper> FullStackDeveloper { get; set; }
        public DbSet<FrontEndDeveloper> FrontEndDeveloper { get; set; }
        public DbSet<BackEndDeveloper> BackEndDeveloper { get; set; }

        public DbSet<TaskToDo> TaskToDo { get; set; }
        public DbSet<SkillTaskToDo> SkillTaskToDo { get; set; }
        public DbSet<Skill> Skill { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeveloperMap());
            modelBuilder.ApplyConfiguration(new FrontEndDeveloperMap());
            modelBuilder.ApplyConfiguration(new BackEndDeveloperMap());
            modelBuilder.ApplyConfiguration(new FullStackDeveloperMap());
            modelBuilder.ApplyConfiguration(new TaskToDoMap());
            modelBuilder.ApplyConfiguration(new SkillMap());
            modelBuilder.ApplyConfiguration(new SkillTaskToDoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder
                .AddInterceptors(new CommandInterceptor())
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
