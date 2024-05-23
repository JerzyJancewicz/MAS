﻿using MAS5.Models.User;
using MAS5.Models.User.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Mas5Test
{
    public class UserModelsTests
    {
        private IList<ValidationResult> ValidateModel(User model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }

        [Fact]
        public void User_ShouldBeInvalid_WhenEmailPropertyIsInvalid()
        {
            // Arrange
            var user = new User(
                new List<UserRole> { UserRole.EMPLOYEE, UserRole.CLIENT },
                "Test",
                "Test",
                "Test", // Invalid email address
                "432543654",
                "Test",
                "test"
            );

            // Act
            var results = ValidateModel(user);

            // Assert
            Assert.Single(results);
            Assert.Equal("Invalid Email", results[0].ErrorMessage);
        }


        [Fact]
        public void Employee_ShouldBeInvalid_WhenPropertiesAreNull()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.EMPLOYEE };
            var employee = new User(userRoles, null, null, null, null, jobTitle: null);

            // Act
            var results = ValidateModel(employee);

            // Assert
            Assert.Equal(5, results.Count); // Name, Surname, Email, PhoneNumber, JobTitle
        }

        [Fact]
        public void Client_ShouldBeInvalid_WhenDriverLicenseIdIsTooShort()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.CLIENT };
            var client = new User(userRoles, "Test", "Test", "test@example.com", "123456789", driverLicenseId: "123");

            // Act
            var results = ValidateModel(client);

            // Assert
            Assert.Single(results);
            Assert.Equal("DriverLicenseId should contain at least 4 and maximum 40 characters", results[0].ErrorMessage);
        }

        [Fact]
        public void Client_ShouldBeInvalid_WhenDriverLicenseIdIsTooLong()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.CLIENT };
            var client = new User(userRoles, "Test", "Test", "test@example.com", "123456789", driverLicenseId: new string('a', 41));

            // Act
            var results = ValidateModel(client);

            // Assert
            Assert.Single(results);
            Assert.Equal("DriverLicenseId should contain at least 4 and maximum 40 characters", results[0].ErrorMessage);
        }

        [Fact]
        public void Client_ShouldBeValid_WhenPropertiesAreCorrect()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.CLIENT };
            var client = new User(userRoles, "Test", "Test", "test@example.com", "123456789", driverLicenseId: "12345");

            // Act
            var results = ValidateModel(client);

            // Assert
            Assert.Empty(results);
        }

        [Fact]
        public void Employee_ShouldBeInvalid_WhenPhoneNumberIsTooShort()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.EMPLOYEE };
            var employee = new User(userRoles, "Test", "Test", "test@example.com", "123", jobTitle: "Test");

            // Act
            var results = ValidateModel(employee);

            // Assert
            Assert.Single(results);
            Assert.Equal("PhoneNumber should contain at least 9 and maximum 12 characters", results[0].ErrorMessage);
        }

        [Fact]
        public void Employee_ShouldBeValid_WhenAllPropertiesAreValid()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.EMPLOYEE };
            var employee = new User(userRoles, "ValidName", "ValidSurname", "valid@example.com", "1234567890", jobTitle: "ValidJobTitle");

            // Act
            var results = ValidateModel(employee);

            // Assert
            Assert.Empty(results);
        }

        [Fact]
        public void Client_ShouldBeInvalid_WhenPropertiesAreNull()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.CLIENT };
            var client = new User(userRoles, null, null, null, null, driverLicenseId: null);

            // Act
            var results = ValidateModel(client);

            // Assert
            Assert.Equal(5, results.Count); // Name, Surname, Email, PhoneNumber, DriverLicenseId
        }

        [Fact]
        public void Client_ShouldBeInvalid_WhenEmailIsInvalid()
        {
            // Arrange
            var userRoles = new List<UserRole> { UserRole.CLIENT };
            var client = new User(userRoles, "Test", "Test", "invalid-email", "123456789", driverLicenseId: "12345");

            // Act
            var results = ValidateModel(client);

            // Assert
            Assert.Single(results);
            Assert.Equal("Invalid Email", results[0].ErrorMessage);
        }

        [Fact]
        public void User_Inheritance_ShouldWorkCorrectly()
        {
            // Arrange
            var employeeRoles = new List<UserRole> { UserRole.EMPLOYEE };
            var employee = new User(employeeRoles, "Test", "Test", "test@example.com", "1234567890", jobTitle: "TestJobTitle");

            var clientRoles = new List<UserRole> { UserRole.CLIENT };
            var client = new User(clientRoles, "ClientTest", "ClientTest", "client@example.com", "0987654321", driverLicenseId: "DL12345");

            // Act
            var employeeResults = ValidateModel(employee);
            var clientResults = ValidateModel(client);

            // Assert
            Assert.Empty(employeeResults); // Employee model is valid
            Assert.Empty(clientResults); // Client model is valid
        }

        [Fact]
        public void User_CanHaveMultipleRoles()
        {
            // Arrange
            var roles = new List<UserRole> { UserRole.CLIENT, UserRole.EMPLOYEE };
            var user = new User(roles, "MultiRole", "User", "multi@example.com", "1234567890", "DL12345", "Manager");

            // Act
            var results = ValidateModel(user);

            // Assert
            Assert.Empty(results); // User with both roles should be valid
        }

        [Fact]
        public void User_ShouldThrowException_WhenNoRolesAssigned()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var user = new User(new List<UserRole>(), "John", "Doe", "john@example.com", "1234567890");
            });
        }

        [Fact]
        public void User_WithEmployeeRole_CannotSetDriverLicenseId()
        {
            // Arrange
            var employeeRoles = new List<UserRole> { UserRole.EMPLOYEE };
            var user = new User(employeeRoles, "Test", "Test", "test@example.com", "1234567890", driverLicenseId: "DL12345");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => user.DriverLicenseId = "DL67890");
        }

        [Fact]
        public void User_WithClientRole_CannotSetJobTitle()
        {
            // Arrange
            var clientRoles = new List<UserRole> { UserRole.CLIENT };
            var user = new User(clientRoles, "Test", "Test", "test@example.com", "1234567890", driverLicenseId: "DL12345");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => user.JobTitle = "Manager");
        }

        [Fact]
        public void IsPolandCitizen_ShouldThrowArgumentException_WhenUserIsNotClient()
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.EMPLOYEE }, "John", "Doe", "john@example.com", "123456789");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.IsPolandCitizen("DL12345"));
        }

        [Fact]
        public void IsPolandCitizen_ShouldThrowArgumentNullException_WhenDriverLicenseIsNull()
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.CLIENT }, "John", "Doe", "john@example.com", "123456789");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.IsPolandCitizen(null));
        }

        [Theory]
        [InlineData("PL12345")]
        [InlineData("pl12345")]
        [InlineData("pl123")]
        public void IsPolandCitizen_ShouldReturnTrue_WhenDriverLicenseIsFromPoland(string driverLicense)
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.CLIENT }, "John", "Doe", "john@example.com", "123456789");

            // Act
            var result = user.IsPolandCitizen(driverLicense);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("DE12345")]
        [InlineData("fr12345")]
        [InlineData("uk123")]
        public void IsPolandCitizen_ShouldReturnFalse_WhenDriverLicenseIsNotFromPoland(string driverLicense)
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.CLIENT }, "John", "Doe", "john@example.com", "123456789");

            // Act
            var result = user.IsPolandCitizen(driverLicense);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPossibleRaise_ShouldThrowArgumentException_WhenUserIsNotEmployee()
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.CLIENT }, "John", "Doe", "john@example.com", "123456789");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.IsPossibleRaise(25));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(20)]
        public void IsPossibleRaise_ShouldReturnFalse_WhenAmmountOfHandledTasksIsNotGreaterThan20(int ammount)
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.EMPLOYEE }, "John", "Doe", "john@example.com", "123456789");

            // Act
            var result = user.IsPossibleRaise(ammount);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(21)]
        [InlineData(30)]
        public void IsPossibleRaise_ShouldReturnTrue_WhenAmmountOfHandledTasksIsGreaterThan20(int ammount)
        {
            // Arrange
            var user = new User(new List<UserRole> { UserRole.EMPLOYEE }, "John", "Doe", "john@example.com", "123456789");

            // Act
            var result = user.IsPossibleRaise(ammount);

            // Assert
            Assert.True(result);
        }
    }
}
