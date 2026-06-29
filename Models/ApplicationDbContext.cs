using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // These lines tell EF Core to create Tasks and Sprints tables in SQL Server
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
    }
}