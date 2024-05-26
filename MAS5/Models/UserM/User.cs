using MAS5.Models.CarM;
using MAS5.Models.CarServiceM;
using MAS5.Models.CustomValidators.UserCM;
using MAS5.Models.OwnerM;
using MAS5.Models.ReservationM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.UserM
{
    public class User : IClient, IEmployee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should contain at least 2 and maximum 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname should contain at least 2 and maximum 50 characters")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "PhoneNumber is required")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "PhoneNumber should contain at least 9 and maximum 12 characters")]
        public string PhoneNumber { get; set; } = string.Empty;

        private string? _driverLicenseId;
        private string? _jobTitle;
        private readonly List<UserRole> userRoles = new List<UserRole>();

        private HashSet<Reservation> _reservations = new HashSet<Reservation>();

        public HashSet<Reservation> Reservations
        {
            get => _reservations;
        }

        public void AddRole(UserRole role)
        {
            if (!userRoles.Contains(role))
            {
                userRoles.Add(role);
            }
        }

        public void RemoveRole(UserRole role)
        {
            if (userRoles.Contains(role))
            {
                userRoles.Remove(role);
            }
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            if (!Reservations.Contains(reservation))
            {
                _reservations.Add(reservation);
                reservation.AddUserReference(this);
            }            
        }

        public void RemoveReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            if (Reservations.Contains(reservation))
            {
                _reservations.Remove(reservation);
                reservation.RemoveUserReference();

                reservation.Car.RemoveReservation(reservation);
                reservation.RemoveCarReference();
            }                
        }

        [CustomStringLength(maximumLength: 40, minimumLength: 4, ErrorMessage = "DriverLicenseId should contain at least 4 and maximum 40 characters")]
        public string? DriverLicenseId
        {
            get
            {
                if (userRoles.Contains(UserRole.CLIENT))
                {
                    return _driverLicenseId ?? string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (userRoles.Contains(UserRole.CLIENT))
                {
                    _driverLicenseId = value;
                }
                else
                {
                    throw new InvalidOperationException("User does not have CLIENT role.");
                }
            }
        }

        [CustomStringLength(maximumLength: 50, minimumLength: 2, ErrorMessage = "JobTitle should contain at least 2 and maximum 50 characters")]
        public string? JobTitle
        {
            get
            {
                if (userRoles.Contains(UserRole.EMPLOYEE))
                {
                    return _jobTitle ?? string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (userRoles.Contains(UserRole.EMPLOYEE))
                {
                    _jobTitle = value;
                }
                else
                {
                    throw new InvalidOperationException("User does not have EMPLOYEE role.");
                }
            }
        }

        public bool IsPolandCitizen(string driverLicense)
        {
            if (!userRoles.Contains(UserRole.CLIENT))
            {
                throw new ArgumentException();
            }
            if (driverLicense == null)
            {
                throw new ArgumentNullException();
            }
            var splittedLicense = driverLicense.ToUpper().ToCharArray();
            var country = "";
            if (splittedLicense.Length >= 2)
            {
                country = splittedLicense[0].ToString() + splittedLicense[1].ToString();
            }
            return country == "PL";
        }

        public bool IsPossibleRaise(int AmmountOfHandledTasks)
        {
            if (!userRoles.Contains(UserRole.EMPLOYEE))
            {
                throw new ArgumentException();
            }
            return AmmountOfHandledTasks > 20;
        }
    }
}