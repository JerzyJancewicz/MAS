using MAS5.Models;
using Microsoft.EntityFrameworkCore;

namespace MAS5.Context
{
    public class MasMpDbContext : DbContext
    {
        public MasMpDbContext(DbContextOptions<MasMpDbContext> options):base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasBaseType<User>();
            modelBuilder.Entity<Client>().HasBaseType<User>();
        }
    }
}
