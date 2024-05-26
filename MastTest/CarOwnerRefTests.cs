using System;
using System.Linq;
using MAS5.Context;
using MAS5.Models.CarM;
using MAS5.Models.OwnerM;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MAS5.Tests
{
    public class CarOwnerRefTests
    {
        private DbContextOptions<MasMpDbContext> GetInMemoryDbContextOptions()
        {
            return new DbContextOptionsBuilder<MasMpDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void CanAddCarToOwner()
        {
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var owner = new Owner
                {
                    Id = 1,
                    Name = "John Doe",
                    PhoneNumber = "1234567890"
                };
                context.Owners.Add(owner);
                context.SaveChanges();

                var car = new Car
                {
                    Id = 1,
                    Model = "Toyota",
                    LicensePlate = "ABC123",
                    Mileage = 10000,
                    OwnerId = owner.Id
                };

                // Act
                context.Cars.Add(car);
                context.SaveChanges();

                // Assert
                var retrievedOwner = context.Owners.Include(o => o.Cars).FirstOrDefault(o => o.Id == owner.Id);
                Assert.NotNull(retrievedOwner);
                Assert.Contains(car, retrievedOwner.Cars);
                Assert.Equal(owner, car.Owner);
            }
        }

        [Fact]
        public void CanRemoveCarFromOwner()
        {
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var owner = new Owner
                {
                    Id = 1,
                    Name = "John Doe",
                    PhoneNumber = "1234567890"
                };
                context.Owners.Add(owner);
                context.SaveChanges();

                var car = new Car
                {
                    Id = 1,
                    Model = "Toyota",
                    LicensePlate = "ABC123",
                    Mileage = 10000,
                    OwnerId = owner.Id
                };

                context.Cars.Add(car);
                context.SaveChanges();

                // Act
                var retrievedOwner = context.Owners.Include(o => o.Cars).FirstOrDefault(o => o.Id == owner.Id);
                Assert.NotNull(retrievedOwner);
                Assert.Contains(car, retrievedOwner.Cars);

                context.Cars.Remove(car);
                context.SaveChanges();

                // Assert
                Assert.DoesNotContain(car, retrievedOwner.Cars);
                Assert.Null(car.Owner);
            }
        }

        /*[Fact]
        public void CanRetrieveCarsForOwner()
        {
            var options = GetInMemoryDbContextOptions();

            using (var context = new MasMpDbContext(options))
            {
                var owner = new Owner
                {
                    Name = "John Doe",
                    PhoneNumber = "1234567890"
                };
                var car1 = new Car
                {
                    Model = "Toyota",
                    LicensePlate = "ABC123",
                    Mileage = 10000
                };
                var car2 = new Car
                {
                    Model = "Honda",
                    LicensePlate = "XYZ456",
                    Mileage = 5000
                };

                car1.AddOwnerReference(owner);
                car2.AddOwnerReference(owner);

                context.Owners.Add(owner);
                context.Cars.AddRange(car1, car2);
                context.SaveChanges();

                var retrievedOwner = context.Owners.Include(o => o.Cars).FirstOrDefault(o => o.Id == owner.Id);

                Assert.NotNull(retrievedOwner);
                Assert.Equal(2, retrievedOwner.Cars.Count);
                Assert.Contains(retrievedOwner.Cars, c => c.Model == car1.Model);
                Assert.Contains(retrievedOwner.Cars, c => c.Model == car2.Model);
            }
        }*/
    }
}
