using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using MAS5.Context;
using MAS5.Models.OwnerM;
using MAS5.Models.CarM;

namespace MAS5.UnitTests
{
    public class OwnerCarTests : IDisposable
    {
        private readonly MasMpDbContext _context;

        public OwnerCarTests()
        {
            // Initialize an in-memory database
            var options = new DbContextOptionsBuilder<MasMpDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new MasMpDbContext(options);
        }

      /*  [Fact]
        public void AddCar_ShouldAddCarToOwner()
        {
            // Arrange
            var owner = new Owner { Name = "John Doe", PhoneNumber = "1234567890" };
            _context.Owners.Add(owner);
            _context.SaveChanges();

            var car = new Car { Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };

            // Act
            owner.AddCar(car);
            _context.SaveChanges();

            // Assert
            Assert.Contains(car, owner.Cars);
            Assert.Equal(owner, car.Owner);
        }*/

        /*[Fact]
        public void RemoveCar_ShouldRemoveCarFromOwner()
        {
            // Arrange
            var owner = new Owner { Name = "John Doe", PhoneNumber = "1234567890" };
            var car = new Car { Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };
            owner.AddCar(car);
            _context.Owners.Add(owner);
            _context.SaveChanges();

            // Act
            owner.RemoveCar(car);
            _context.SaveChanges();

            // Assert
            Assert.DoesNotContain(car, owner.Cars);
            Assert.Null(car.Owner);
        }*/

        [Fact]
        public void AddCar_NullCar_ShouldThrowArgumentNullException()
        {
            // Arrange
            var owner = new Owner { Name = "John Doe", PhoneNumber = "1234567890" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => owner.AddCar(null));
        }

        [Fact]
        public void RemoveCar_NullCar_ShouldThrowArgumentNullException()
        {
            // Arrange
            var owner = new Owner { Name = "John Doe", PhoneNumber = "1234567890" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => owner.RemoveCar(null));
        }

        /*[Fact]
        public void RemoveReference_ShouldSetOwnerToNull()
        {
            // Arrange
            var car = new Car { Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };
            var owner = new Owner { Name = "John Doe", PhoneNumber = "1234567890" };
            car.AddOwnerReference(owner);
            _context.Owners.Add(owner);
            _context.SaveChanges();

            // Act
            car.RemoveReference();
            _context.SaveChanges();

            // Assert
            Assert.Null(car.Owner);
            Assert.Null(owner.Cars.FirstOrDefault(E => E.Owner == owner));
        }*/

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
