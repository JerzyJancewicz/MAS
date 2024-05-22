using System.ComponentModel.DataAnnotations;

namespace MAS5.Models
{
    public class Employee : User
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string JobTtitle { get; set; } = string.Empty;
    }
}
