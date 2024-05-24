using MAS5.Models.Car;
using MAS5.Models.Owner;
using System;
using Xunit;

namespace MAS5.UnitTests
{
    public class OwnerCarTests
    {
        [Fact]
        public void AddCar_ShouldAddCarToOwner()
        {
            // Arrange
            var owner = new Owner { Id = 1, Name = "John Doe", PhoneNumber = "1234567890" };
            var car = new Car { Id = 1, Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };

            // Act
            owner.AddCar(car);

            // Assert
            Assert.Contains(car, owner.Cars);
            Assert.Equal(owner, car.Owner);
        }

        [Fact]
        public void RemoveCar_ShouldRemoveCarFromOwner()
        {
            // Arrange
            var owner = new Owner { Id = 1, Name = "John Doe", PhoneNumber = "1234567890" };
            var car = new Car { Id = 1, Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };
            owner.AddCar(car);

            // Act
            owner.RemoveCar(car);

            // Assert
            Assert.DoesNotContain(car, owner.Cars);
            Assert.Null(car.Owner);
        }

        [Fact]
        public void AddCar_NullCar_ShouldThrowArgumentNullException()
        {
            // Arrange
            var owner = new Owner { Id = 1, Name = "John Doe", PhoneNumber = "1234567890" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => owner.AddCar(null));
        }

        [Fact]
        public void RemoveCar_NullCar_ShouldThrowArgumentNullException()
        {
            // Arrange
            var owner = new Owner { Id = 1, Name = "John Doe", PhoneNumber = "1234567890" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => owner.RemoveCar(null));
        }

        [Fact]
        public void SetOwner_ShouldThrowArgumentNullException_WhenOwnerIsNull()
        {
            // Arrange
            var car = new Car { Id = 1, Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => car.Owner = null);
        }

        /*[Fact]
        public void RemoveReference_ShouldSetOwnerToNull()
        {
            // Arrange
            var car = new Car { Id = 1, Model = "Toyota", LicensePlate = "ABC123", Mileage = 10000 };
            var owner = new Owner { Id = 1, Name = "John Doe", PhoneNumber = "1234567890" };
            car.Owner = owner;

            // Act
            car.RemoveReference();

            // Assert
            Assert.Null(car.Owner);
        }*/
    }
}
