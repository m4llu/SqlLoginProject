using Microsoft.EntityFrameworkCore;

namespace SqlLogin
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table and column mappings, constraints, etc.
            modelBuilder.Entity<TaskItem>().ToTable("Tasks");
            modelBuilder.Entity<TaskItem>().HasKey(t => t.TaskId);
            // Add any other configurations as needed
        }
    }
}






























