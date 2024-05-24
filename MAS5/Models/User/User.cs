using MAS5.Models.CustomValidators.User;
using MAS5.Models.Reservation;
using MAS5.Models.User;
using MAS5.Models.User.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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
    private readonly List<UserRole> userRoles;

    private HashSet<Reservation> _reservations = new HashSet<Reservation>();

    public User(List<UserRole> roles, string name, string surname, string email, string phoneNumber, string driverLicenseId = null, string jobTitle = null)
    {
        if(roles.Count == 0)
        {
            throw new ArgumentException("User does not have any role assigned");
        }
        userRoles = roles;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;

        if (userRoles.Contains(UserRole.CLIENT) && driverLicenseId != null)
        {
            DriverLicenseId = driverLicenseId;
        }

        if (userRoles.Contains(UserRole.EMPLOYEE) && jobTitle != null)
        {
            JobTitle = jobTitle;
        }
    }
    public ReadOnlyCollection<Reservation> Reservations
    {
        get { return new ReadOnlyCollection<Reservation>(_reservations.ToList()); }
    }
    /*public void AddReservation(Reservation reservation)
    {
        if (reservation == null) { throw new ArgumentNullException(); }
        _reservations.Add(reservation);
        reservation.User = this;
    }

    public void RemoveReservation(Reservation reservation)
    {
        if (reservation == null) { throw new ArgumentNullException(); }
        _reservations.Remove(reservation);
        reservation.RemoveUserReference();
    }*/

    [CustomStringLength(maximumLength: 40, minimumLength: 4, ErrorMessage = "DriverLicenseId should contain at least 4 and maximum 40 characters")]
    public string DriverLicenseId
    {
        get
        {
            if (userRoles.Contains(UserRole.CLIENT))
            {
                return _driverLicenseId ?? string.Empty;
            }
            else
            {
                return null;
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
    public string JobTitle
    {
        get
        {
            if (userRoles.Contains(UserRole.EMPLOYEE))
            {
                return _jobTitle ?? string.Empty;
            }
            else
            {
                return null;
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
