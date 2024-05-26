using System;
using System.Linq;
using System.Collections.Generic;
using MAS5.Models.CarM;
using MAS5.Models.ReservationM;
using MAS5.Models.UserM;
using Microsoft.EntityFrameworkCore;
using MAS5.Context;

namespace MAS5.Tests
{
    public class CarUserReservationRefTests
    {
        private DbContextOptions<MasMpDbContext> GetInMemoryDbContextOptions()
        {
            return new DbContextOptionsBuilder<MasMpDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void CanAddReservationToUser()
        {
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var user = new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123456789"
                };
                context.Users.Add(user);
                context.SaveChanges();

                var reservation = new Reservation
                {
                    Id = 1,
                    Name = "Reservation 1",
                    Description = "Test reservation",
                    UserId = user.Id,
                };

                // Act
                context.Reservations.Add(reservation);
                context.SaveChanges();

                // Assert
                var retrievedUser = context.Users.Include(u => u.Reservations).FirstOrDefault(u => u.Id == user.Id);
                Assert.NotNull(retrievedUser);
                Assert.Contains(reservation, retrievedUser.Reservations);
                Assert.Equal(user, reservation.User);
            }
        }

        [Fact]
        public void CanRemoveReservationFromUser()
        {
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var user = new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123456789"
                    // Add any other necessary properties...
                };
                context.Users.Add(user);
                context.SaveChanges();

                var reservation = new Reservation
                {
                    Id = 1,
                    Name = "Reservation 1",
                    Description = "Test reservation",
                    UserId = user.Id,
                    // Add any other necessary properties...
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();

                // Act
                var retrievedUser = context.Users.Include(u => u.Reservations).FirstOrDefault(u => u.Id == user.Id);
                Assert.NotNull(retrievedUser);
                Assert.Contains(reservation, retrievedUser.Reservations);

                retrievedUser.RemoveReservation(reservation);
                context.SaveChanges();

                // Assert
                Assert.DoesNotContain(reservation, retrievedUser.Reservations);
                Assert.Null(reservation.User);
            }
        }
        [Fact]
        public void CanAddReservationToCar()
        {
            // Arrange
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var car = new Car
                {
                    Id = 1,
                    Model = "Toyota",
                    LicensePlate = "ABC123",
                    Mileage = 10000
                };
                context.Cars.Add(car);
                context.SaveChanges();

                var reservation = new Reservation
                {
                    Id = 1,
                    Name = "Reservation 1",
                    Description = "Test reservation",
                    CarId = car.Id,
                };

                // Act
                context.Reservations.Add(reservation);
                context.SaveChanges();

                // Assert
                var retrievedCar = context.Cars.Include(c => c.Reservations).FirstOrDefault(c => c.Id == car.Id);
                Assert.NotNull(retrievedCar);
                Assert.Contains(reservation, retrievedCar.Reservations);
                Assert.Equal(car, reservation.Car);
            }
        }

        [Fact]
        public void CanRemoveReservationFromCar()
        {
            // Arrange
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var car = new Car
                {
                    Id = 1,
                    Model = "Toyota",
                    LicensePlate = "ABC123",
                    Mileage = 10000
                };
                context.Cars.Add(car);
                context.SaveChanges();

                var reservation = new Reservation
                {
                    Id = 1,
                    Name = "Reservation 1",
                    Description = "Test reservation",
                    CarId = car.Id,
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();

                // Act
                var retrievedCar = context.Cars.Include(c => c.Reservations).FirstOrDefault(c => c.Id == car.Id);
                Assert.NotNull(retrievedCar);
                Assert.Contains(reservation, retrievedCar.Reservations);

                retrievedCar.RemoveReservation(reservation);
                context.SaveChanges();

                // Assert
                Assert.DoesNotContain(reservation, retrievedCar.Reservations);
                Assert.Null(reservation.Car);
            }
        }
    }
}
