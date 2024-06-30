using Microsoft.EntityFrameworkCore;
using TaskListDemo.Models;

namespace TaskListDemo.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<JobList> JobLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "管理員", DisplayNum = 1 },
                new Role { Id = 2, RoleName = "使用者", DisplayNum = 2 },
                new Role { Id = 3, RoleName = "工程師", DisplayNum = 3 }
                );

            modelBuilder.Entity<JobList>().HasData(
                new JobList { JobId = 1, Title = "無法上網", Description = "剛才突然不能上網"},
                new JobList { JobId = 2, Title = "無法開機", Description = "剛剛突然關機，無法重開"}
                );
        }
    }
}
