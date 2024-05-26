using MAS5.Models.CarM;
using MAS5.Models.OwnerM;
using MAS5.Models.UserM;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MAS5.Models.CarServiceM
{
    public class CarService
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }

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


        private Car? _car;

        public  Car Car
        {
            get => _car;
            private set 
            {
                _car = value;
            }
        }

        public void RemoveCarReference()
        {
            if (_car == null) { throw new ArgumentNullException(); }
            _car.RemoveCarServiceReference(this);

            foreach (var reservation in _car.Reservations)
            {
                _car.RemoveReservation(reservation);
            }
            _car.RemoveReference();
            _car = null;
        }

        public void AddCarReference(Car car)
        {
            if (car == null) { throw new ArgumentNullException(); }
            _car = car;
            car.AddCarServiceReference(this);
        }
    }
}
