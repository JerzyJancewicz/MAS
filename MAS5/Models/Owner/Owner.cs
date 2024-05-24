using MAS5.Models.Car;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.Owner
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should contain at least 2 and maximum 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "PhoneNumber is required")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "PhoneNumber should contain at least 9 and maximum 12 characters")]
        public string PhoneNumber { get; set; } = string.Empty;

        private HashSet<Models.Car.Car> _cars = new HashSet<Models.Car.Car>();

        public ReadOnlyCollection<Models.Car.Car> Cars
        {
            get { return new ReadOnlyCollection<Models.Car.Car>(_cars.ToList()); }
        }

        public void AddCar(Models.Car.Car car)
        {
            if (car == null) { throw new ArgumentNullException(); }
            _cars.Add(car);
            car.Owner = this;
        }

        public void RemoveCar(Models.Car.Car car)
        {
            if (car == null) { throw new ArgumentNullException(); }
            _cars.Remove(car);
            car.RemoveReference();
        }
    }
}
