using MAS5.Models.UserM;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MAS5.Models.Service
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ServiceDate is required")]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime),
            "1900-01-01",
            "9999-12-31",
            ErrorMessage = "Service Date must be between {1} and {2}"
        )]
        public DateTime ServiceDate { get; } = DateTime.Now.ToLocalTime();

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name should contain at least 2 and maximum 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Description should contain maximum 250 characters")]
        public string Description { get; set; } = string.Empty;

        public static double SERVICE_COST_VALUE = 1.2;

        private HashSet<User> users = new HashSet<User> ();

        
    }
}
