using MAS5.Models.CarM;
using MAS5.Models.CarServiceM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas5Test
{
    public class ServiceModelsTests
    {
        private IList<ValidationResult> ValidateModel(CarService model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }

        [Fact]
        public void Service_ShouldBeInvalid_WhenNameIsNull()
        {
            // Arrange
            var service = new CarService()
            {
                Name = null,
                Description = "Test Description"
            };

            // Act
            var results = ValidateModel(service);

            // Assert
            Assert.Single(results);
            Assert.Equal("Name is required", results[0].ErrorMessage);
        }

        [Fact]
        public void Service_ShouldBeInvalid_WhenNameIsTooShort()
        {
            // Arrange
            var service = new CarService()
            {
                Name = "A", // Invalid: too short
                Description = "Test Description"
            };

            // Act
            var results = ValidateModel(service);

            // Assert
            Assert.Single(results);
            Assert.Equal("Name should contain at least 2 and maximum 100 characters", results[0].ErrorMessage);
        }

        [Fact]
        public void Service_ShouldBeInvalid_WhenDescriptionIsTooLong()
        {
            // Arrange
            var service = new CarService()
            {
                Name = "Valid Name",
                Description = new string('A', 251) // Invalid: too long
            };

            // Act
            var results = ValidateModel(service);

            // Assert
            Assert.Single(results);
            Assert.Equal("Description should contain maximum 250 characters", results[0].ErrorMessage);
        }

        [Fact]
        public void Service_ShouldBeValid_WhenAllPropertiesAreValid()
        {
            // Arrange
            var service = new CarService()
            {
                Name = "Valid Name",
                Description = "Valid Description"
            };

            // Act
            var results = ValidateModel(service);

            // Assert
            Assert.Empty(results);
        }
    }
}
