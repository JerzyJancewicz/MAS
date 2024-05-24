using MAS5.Models.Car;
using MAS5.Models.User;


using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.Reservation
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should contain at least 2 and maximum 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Description should contain at least 10 and maximum 250 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "ServiceDate is required")]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime),
            "1900-01-01",
            "9999-12-31",
            ErrorMessage = "Service Date must be between {1} and {2}"
        )]
        public DateTime ReservationDate { get; set; } = DateTime.Now.ToLocalTime();

        private static double RESERVATION_COST_VALUE = 1.2;

        private Car.Car? _car = new Car.Car();
        //private User.User? _user = new User.User();

        public Reservation(Car.Car car)
        {
            if (car == null) { throw new ArgumentNullException(); }
            _car = car;

            _car.AddReservation(this);
            //_user.AddReservation(this);
        }

        public Car.Car Car
        {
            get => _car!;
            set
            {
                if (value == null) 
                {
                    throw new ArgumentNullException();
                }
                _car = value;
            }
        }
        /*public User.User User
        {
            get => _user!;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _user = value;
            }
        }*/

        /*internal void RemoveUserReference()
        {
            _user = null;
        }*/

        internal void RemoveCarReference() 
        {
            _car = null;
        }
    }
}
