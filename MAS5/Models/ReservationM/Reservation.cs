using MAS5.Models.CarM;
using MAS5.Models.UserM;
using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.ReservationM
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

        private Car? _car;
        private User? _user;

        public Reservation(Car car, User user)
        {
            if (car == null || user == null) { throw new ArgumentNullException(); }
            _car = car;
            _user = user;

            _car.AddReservation(this);
            _user.AddReservation(this);
        }

        public Car Car
        {
            get => _car!;
            private set
            {
                _car = value;
            }
        }
        public User User
        {
            get => _user!;
            private set
            {
                _user = value;
            }
        }

        public void RemoveUserReference()
        {
            if (_user != null)
            {
                _user.RemoveReservation(this);
            }
            _user = null;
        }

        public void RemoveCarReference() 
        {
            if (_car != null)
            {
                _car.RemoveReservation(this);
            }
            _car = null;
        }

        public void AddUserReference(User user)
        {
            if (user == null) { throw new ArgumentNullException(); }
            _user = user;
            user.AddReservation(this);
        }
        public void AddCarReference(Car car)
        {
            if (car == null) { throw new ArgumentNullException(); }
            _car = car;
            car.AddReservation(this);
        }
    }
}
