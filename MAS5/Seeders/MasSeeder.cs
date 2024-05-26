using MAS5.Context;
using MAS5.Models.CarM;
using MAS5.Models.CarServiceM;
using MAS5.Models.OwnerM;
using MAS5.Models.ReservationM;
using MAS5.Models.UserM;

namespace MAS5.Seeders
{
    public class MasSeeder
    {
        private readonly MasMpDbContext _context;

        public MasSeeder(MasMpDbContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            var owner = new Owner { Name = "John Doe", PhoneNumber = "123456789" };

            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();

            var car = new Car { Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000, OwnerId = owner.Id };
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            var carService = new CarService { Name = "Oil Change", Description = "Regular oil change service", CarId = car.Id };

            await _context.CarServices.AddAsync(carService);
            await _context.SaveChangesAsync();

            var user = new User { Name = "Alice", Surname = "Smith", Email = "alice@example.com", PhoneNumber = "987654321"};
            user.AddRole(UserRole.CLIENT);
            user.AddRole(UserRole.EMPLOYEE);
            user.DriverLicenseId = "AB12345";
            user.JobTitle = "Manager";
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var reservation = new Reservation { Name = "Service Appointment", Description = "Appointment for service", ReservationDate = DateTime.Now, CarId = car.Id, UserId = user.Id };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
