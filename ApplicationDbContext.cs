
using Btec_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Btec_Website
{

    public class ApplicationDbContext : DbContext
    {
        // Define your DbSet properties for each entity you want to persist

        // Example:
        // public DbSet<User> Users { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }

        string ConnectionString =
        "Server=DUCKKY;Database=BTEC;"
        +
        "Integrated Security=true;TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database provider and connection string
           // optionsBuilder.UseSqlServer("your_connection_string_here");

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });

            // Other entity configurations
        }
      
    }
}
