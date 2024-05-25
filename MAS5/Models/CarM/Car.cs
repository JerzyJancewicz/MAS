using MAS5.Models.OwnerM;
using MAS5.Models.ReservationM;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.CarM
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Model should contain at least 2 and maximum 20 characters")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "LicensePlate is required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "LicensePlate should contain at least 5 and maximum 10 characters")]
        public string LicensePlate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mileage is required")]
        [MinLength(0)]
        public double Mileage { get; set; }

        private Owner? _owner = new Owner();
        private HashSet<Reservation> _reservations = new HashSet<Reservation>();

        public Owner Owner
        {
            get => _owner!;
            private set 
            {
                _owner = value;
            }
        }
        public ReadOnlyCollection<Reservation> Reservations
        {
            get { return new ReadOnlyCollection<Reservation>(_reservations.ToList()); }
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            _reservations.Add(reservation);
            reservation.AddCarReference(this);
        }

        public void RemoveReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            _reservations.Remove(reservation);
            reservation.RemoveCarReference();
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
