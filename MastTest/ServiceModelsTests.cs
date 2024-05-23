using MAS5.Models.Service;
using MAS5.Models.User.User;
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
        private IList<ValidationResult> ValidateModel(Service model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }

        // TODO: Chnge it to work properly
        /*[Fact]
        public void Service_ShouldHaveProperlyFormattedDate()
        {
            // Arrange
            var service = new Service
            {
                Name = "Test",
                Description = "Test Description"
            };

            // Act
            var formattedDateTime = service.ServiceDate;

            // Assert
            var currentDateTime = DateTime.Now.ToLocalTime();
            Assert.Equal(currentDateTime, formattedDateTime);
        }*/

        [Fact]
        public void Service_ShouldBeInvalid_WhenNameIsNull()
        {
            // Arrange
            var service = new Service
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
            var service = new Service
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
            var service = new Service
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
            var service = new Service
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
