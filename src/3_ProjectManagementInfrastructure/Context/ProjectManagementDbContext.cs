using ProjectManagementInfrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ProjectManagementInfrastructure.Context
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: ProjectManagementDbContext
    /// </summary>
    public class ProjectManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options) { }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<States> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>().Navigation(t => t.Tasks).AutoInclude();
            modelBuilder.Entity<Projects>().Navigation(t => t.States).AutoInclude();
            modelBuilder.Entity<Tasks>().Navigation(t => t.States).AutoInclude();

            modelBuilder.Entity<Projects>().HasMany(e => e.Tasks).WithOne(e => e.Projects).OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<States>().HasData(
              new States { Id = 1, Name = "Started" },
              new States { Id = 2, Name = "In Progress" },
              new States { Id = 3, Name = "Completed" }
            );

            modelBuilder.Entity<Projects>().HasData(
                new Projects { Id = 1, Name = "Digital Market", Description = "Digital Market for customers", StatesId = 1 },
                new Projects { Id = 2, Name = "Digital Cars", Description = "Digital Cars for customers", StatesId = 1 }
            );

            modelBuilder.Entity<Tasks>().HasData(
              new Tasks { Id = 1, Name = "Initial Information of Client", Description = "Task for Initial Information of Client", ProjectsId = 1, StatesId = 1 },
              new Tasks { Id = 2, Name = "Solution Builder", Description = "Task for Solution Builder", ProjectsId = 1, StatesId = 1 },
              new Tasks { Id = 3, Name = "Developer Interviews", Description = "Task for Developer Interviews", ProjectsId = 1, StatesId = 1 }              
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
              new ApplicationUser
              {
                  FirstName = "Admin",
                  LastName = "User",                  
                  UserName = "admin",                  
                  Email = "admin@projects.com",
                  NormalizedEmail = "ADMIN@PROJECTS.COM",
                  PasswordHash = "AQAAAAEAACcQAAAAEAqkXO45fXuBRZwwKNNv/sEtaH9GqujX/knklRfWThORSnlWoQiNfPdfpmGMW0yMKg==",
                  LockoutEnabled = true
              }
            );

            base.OnModelCreating(modelBuilder);

        }

    }
}
