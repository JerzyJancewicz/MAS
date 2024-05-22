using System.ComponentModel.DataAnnotations;

namespace MAS5.Models
{
    public class Client : User
    {
        [Required]
        [MaxLength(40)]
        [MinLength(5)]
        public string DriverLicenseId { get; set; } = string.Empty;
    }
}
