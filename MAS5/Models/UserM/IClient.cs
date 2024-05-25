using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.UserM
{
    public interface IClient
    {
        public string DriverLicenseId { get; set; }
        public bool IsPolandCitizen(string driverLicense);
    }
}
