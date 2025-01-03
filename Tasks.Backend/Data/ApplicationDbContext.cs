using Microsoft.EntityFrameworkCore;
using Tasks.Backend.Models;

namespace Tasks.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Defina os DbSets para suas tabelas
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
