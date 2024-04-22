using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace SqlLogin
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=db1;Uid=username;Pwd=password;";

            optionsBuilder.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(10, 0, 6)) // <-- use ServerVersion.FromString() with a "-mysql" suffix instead
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().ToTable("Tasks");
            modelBuilder.Entity<TaskItem>().HasKey(t => t.TaskId);
        }
    }
}

