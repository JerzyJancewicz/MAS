using MAS5.Models.CarM;
using MAS5.Models.CarServiceM;
using MAS5.Models.OwnerM;
using MAS5.Models.ReservationM;
using MAS5.Models.UserM;
using Microsoft.EntityFrameworkCore;

namespace MAS5.Context
{
    public class MasMpDbContext : DbContext
    {
        public MasMpDbContext(DbContextOptions<MasMpDbContext> options):base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CarService> CarServices { get; set; } 
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasDiscriminator<string>("UserRole")
            .HasValue<User>("User");

            // Car 1..* - 1 Owner
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId);

            // User 1 - 0..* Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            // Car 1 - 0..* Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId);

            // Car 1 - 0..* CarService
            modelBuilder.Entity<CarService>()
                .HasOne(cs => cs.Car)
                .WithMany(c => c.CarServices)
                .HasForeignKey(cs => cs.CarId);           
        }
    }
}
