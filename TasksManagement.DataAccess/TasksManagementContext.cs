using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TasksManagement.DataAccess.Configuration;
using TasksManagement.Domain;

namespace TasksManagement.DataAccess
{
    public class TasksManagementContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Developer",
                    CreatedAt = DateTime.Now
                },
                new Role
                {
                    Id = 2,
                    Name = "Project Manager",
                    CreatedAt = DateTime.Now
                },
                new Role
                {
                    Id = 3,
                    Name = "Administrator",
                    CreatedAt = DateTime.Now
                }
            };
            var users = new List<User> {
                new User{
                    Id=1,
                    CreatedAt=DateTime.Now,
                    FirstName="Pera",
                    LastName="Peric",
                    Username="perica",
                    Email="pera@gmail.com",
                    Password="sifra1",
                    RoleId=1
                },
                new User
                {
                    Id=2,
                    CreatedAt=DateTime.Now,
                    FirstName="Marcos",
                    LastName="Swill",
                    Username="marcosswill",
                    Email="marcosswill@gmail.com",
                    Password="sifra1",
                    RoleId=2
                },
                new User
                {
                    Id=3,
                    CreatedAt=DateTime.Now,
                    FirstName="Lina",
                    LastName="Brown",
                    Username="linabrown",
                    Email="linabrown@gmail.com",
                    Password="sifra1",
                    RoleId=3
                },
                new User
                {
                    Id=5,
                    CreatedAt=DateTime.Now,
                    FirstName="Sandra",
                    LastName="Mladenovic",
                    Username="sandra",
                    Email="sandra@gmail.com",
                    Password="sifra1",
                    RoleId=2
                }
            };

            var statuses = new List<StatusType>
            {
                new StatusType
                {
                    Id = 1,
                    Name = "new",
                    CreatedAt = DateTime.Now
                },
                new StatusType
                {
                    Id = 2,
                    Name = "in progress",
                    CreatedAt = DateTime.Now
                },
                new StatusType
                {
                    Id = 3,
                    Name = "finished",
                    CreatedAt = DateTime.Now
                }
            };
            var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "Online Book Store",
                    CreatedAt = DateTime.Now,
                    Code = "OBS"
                },
                new Project
                {
                    Id = 2,
                    Name = "Online Language Platform",
                    CreatedAt = DateTime.Now,
                    Code = "OLP"
                },
                new Project
                {
                    Id = 3,
                    Name = "Shoes web shop",
                    CreatedAt = DateTime.Now,
                    Code = "SWS"
                }
            };

            var assignment = new List<Assignment>
            {
                new Assignment
                {
                    Id = 1,
                    Description = "Create new user",
                    Deadline = DateTime.Now.AddDays(10),
                    UserId = 1,
                    ProjectId = 1,
                    CreatedAt = DateTime.Now,
                    Progress = 0,
                    StatusTypeId = 1
                }
            };



            var allowed = Enumerable.Range(1, 30).ToList();
            var cases = new List<UserUseCase>();
            foreach (var a in allowed)
            {
                cases.Add(new UserUseCase
                {
                    Id = a,
                    UserId = 1,
                    UseCaseId = a
                });

            }
            modelBuilder.Entity<UserUseCase>().HasData(cases);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Assignment>().HasData(assignment);
            modelBuilder.Entity<StatusType>().HasData(statuses);
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StatusTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HJ4SKN6;Initial Catalog=TaskManagement;Integrated Security=True");

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {

                if (entry.Entity is Entity e)
                {

                    switch (entry.State)
                    {

                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
