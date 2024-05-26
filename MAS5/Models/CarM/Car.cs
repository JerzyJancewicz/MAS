using MAS5.Models.CarServiceM;
using MAS5.Models.OwnerM;
using MAS5.Models.ReservationM;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS5.Models.CarM
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Model should contain at least 2 and maximum 20 characters")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "LicensePlate is required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "LicensePlate should contain at least 5 and maximum 10 characters")]
        public string LicensePlate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mileage is required")]
        [MinLength(0)]
        public double Mileage { get; set; }

        private Owner? _owner;
        private HashSet<CarService> _carServices = new HashSet<CarService>();
        private HashSet<Reservation> _reservations = new HashSet<Reservation>();

        public Owner Owner
        {
            get => _owner!;
            private set 
            {
                _owner = value;
            }
        }

        public HashSet<CarService> CarServices
        {
            get => _carServices;
        }
        public HashSet<Reservation> Reservations
        {
            get => _reservations;
        }

        public void RemoveCarServiceReference(CarService carService)
        {
            if (carService == null) { throw new ArgumentNullException(); }
            if (CarServices.Contains(carService))
            {
                _carServices.Remove(carService);
                carService.RemoveCarReference();
            }              
        }

        public void AddCarServiceReference(CarService carService) 
        {
            if (carService == null) { throw new ArgumentNullException(); }
            if (!CarServices.Contains(carService)) 
            {
                _carServices.Add(carService);
                carService.AddCarReference(this);
            }
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            if (!Reservations.Contains(reservation))
            {
                _reservations.Add(reservation);
                reservation.AddCarReference(this);
            }            
        }

        public void RemoveReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            if (Reservations.Contains(reservation))
            {
                _reservations.Remove(reservation);
                reservation.RemoveCarReference();

                reservation.User.RemoveReservation(reservation);
                reservation.RemoveUserReference();
            }                
        }

        public void RemoveReference()
        {
            if (_owner != null)
            {
                _owner.RemoveCar(this);
            }
            _owner = null;
        }

        public void AddOwnerReference(Owner owner) 
        {
            if (owner == null) { throw new ArgumentNullException(); }
            _owner = owner;
            owner.AddCar(this);
        }
    }
}
