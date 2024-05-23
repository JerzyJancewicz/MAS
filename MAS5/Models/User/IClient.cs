using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.User.User
{
    public interface IClient
    {
        public string DriverLicenseId { get; set; }
        public bool IsPolandCitizen(string driverLicense);
    }
}
