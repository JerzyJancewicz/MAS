using System;
using System.Linq;
using System.Collections.Generic;
using MAS5.Models.CarM;
using MAS5.Models.CarServiceM;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MAS5.Context;

namespace MAS5.Tests
{
    public class CarCarServiceRefTests
    {
        private DbContextOptions<MasMpDbContext> GetInMemoryDbContextOptions()
        {
            return new DbContextOptionsBuilder<MasMpDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void CanAddCarServiceToCar()
        {
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

                var carService = new CarService
                {
                    Id = 1,
                    Name = "Oil Change",
                    Description = "Regular oil change service",
                    CarId = car.Id
                };

                // Act
                context.CarServices.Add(carService);
                context.SaveChanges();

                // Assert
                var retrievedCar = context.Cars.Include(c => c.CarServices).FirstOrDefault(c => c.Id == car.Id);
                Assert.NotNull(retrievedCar);
                Assert.Contains(carService, retrievedCar.CarServices);
                Assert.Equal(car, carService.Car);
            }
        }

        [Fact]
        public void CanRemoveCarServiceFromCar()
        {
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

                var carService = new CarService
                {
                    Id = 1,
                    Name = "Oil Change",
                    Description = "Regular oil change service",
                    CarId = car.Id
                };

                context.CarServices.Add(carService);
                context.SaveChanges();

                // Act
                var retrievedCar = context.Cars.Include(c => c.CarServices).FirstOrDefault(c => c.Id == car.Id);
                Assert.NotNull(retrievedCar);
                Assert.Contains(carService, retrievedCar.CarServices);

                context.CarServices.Remove(carService);
                context.SaveChanges();

                // Assert
                Assert.DoesNotContain(carService, retrievedCar.CarServices);
                Assert.Null(carService.Car);
            }
        }

        /*[Fact]
        public void CanRetrieveCarServicesForCar()
        {
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var car = new Car
                {
                    Model = "Toyota",
                    LicensePlate = "ABC123",
                    Mileage = 10000
                };
                var carService1 = new CarService()
                {
                    Name = "Oil Change",
                    Description = "Regular oil change service",
                };
                var carService2 = new CarService()
                {
                    Name = "Tire Rotation",
                    Description = "Tire rotation service",
                };

                context.Cars.Add(car);
                context.CarServices.AddRange(carService1, carService2);
                context.SaveChanges();

                var retrievedCar = context.Cars.Include(c => c.CarServices).FirstOrDefault(c => c.Id == car.Id);

                Assert.NotNull(retrievedCar);
                Assert.Equal(2, retrievedCar.CarServices.Count);
                Assert.Contains(retrievedCar.CarServices, cs => cs.Name == carService1.Name);
                Assert.Contains(retrievedCar.CarServices, cs => cs.Name == carService2.Name);
            }
        }*/
    }
}
