using Microsoft.EntityFrameworkCore;
using TodoListDemo.Models;

namespace TodoListDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TodoList> todoLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>().HasData(
                new TodoList { Id = 1, Title = "看牙醫", Description = "去桃園牙醫診所看牙醫", Status = true, StartTime = new DateTime(2024, 06, 15, 14, 00, 00), EndTime = new DateTime(2024, 06, 15, 20, 00, 00, 00), CreateTime = DateTime.Now}
                );
        }
    }
}
