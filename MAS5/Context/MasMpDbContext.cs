using MAS5.Models.UserM;
using Microsoft.EntityFrameworkCore;

namespace MAS5.Context
{
    public class MasMpDbContext : DbContext
    {
        public MasMpDbContext(DbContextOptions<MasMpDbContext> options):base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<IEmployee> Employees { get; set; }
        public DbSet<IClient> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IEmployee>().HasBaseType<User>();
            modelBuilder.Entity<IClient>().HasBaseType<User>();
        }
    }
}
