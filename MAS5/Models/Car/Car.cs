using MAS5.Models.Owner;
using MAS5.Models.Reservation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.Car
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

        private Models.Owner.Owner? _owner = new Models.Owner.Owner();
        private HashSet<Models.Reservation.Reservation> _reservations = new HashSet<Models.Reservation.Reservation>();

        public Models.Owner.Owner Owner
        {
            get => _owner!;
            set 
            {
                if (value == null) 
                {
                    throw new ArgumentNullException();
                }
                _owner = value;
            }
        }
        public ReadOnlyCollection<Models.Reservation.Reservation> Reservations
        {
            get { return new ReadOnlyCollection<Models.Reservation.Reservation>(_reservations.ToList()); }
        }

        public void AddReservation(Models.Reservation.Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            _reservations.Add(reservation);
            reservation.Car = this;
        }

        public void RemoveReservation(Models.Reservation.Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(); }
            _reservations.Remove(reservation);
            reservation.RemoveCarReference();
        }

        // ????????????????????????????????????
        internal void RemoveReference()
        {
            _owner = null;
        }
    }
}
