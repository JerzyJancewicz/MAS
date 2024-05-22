using System.ComponentModel.DataAnnotations;

namespace MAS5.Models
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name{ get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        [MaxLength (12)]
        [MinLength(9)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
