using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Truck
{
    public class DeliveryTruck : Truck
    {
        private string _cargoType;

        public string CargoType
        {
            get => _cargoType;
            set
            {
                if (_cargoType is null || GetCargoTypeCost(_cargoType) == 1.0)
                {
                    throw new ArgumentException("There is no type on that name");
                }
            }
        }

        public DeliveryTruck(string model, DateTime dateOfProduction, string registrationNumber, string fuelType, double fuelConsumption, long currentMileage, string status, string cargoType) : base(model, dateOfProduction, registrationNumber, fuelType, fuelConsumption, currentMileage, status)
        {
            CargoType = cargoType;
        }

        private double GetCargoTypeCost(string cargoType)
        {
            switch (cargoType.ToLower())
            {
                case "perishable goods":
                    return 10.0;
                case "hazardous materials":
                    return 15.0;
                case "fragile items":
                    return 8.0;
                default:
                    return 1.0;
            }
        }
        public override double CalculateEnvironmentalImpact()
        {
            var EnvironmentalImpact = (FuelConsumption * ConstantFuelFactor) +
                GetCargoTypeCost(CargoType) * 3;

            return EnvironmentalImpact;
        }
    }
}
