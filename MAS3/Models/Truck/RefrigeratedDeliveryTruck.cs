using MAS3.Models.Truck.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Truck
{
    public class RefrigeratedDeliveryTruck : DeliveryTruck ,IRefrigeratedTruck
    {
        public string _cargoType { get; }
        public RefrigeratedDeliveryTruck(string model, DateTime dateOfProduction, string registrationNumber, string fuelType, double fuelConsumption, long currentMileage, string status, string cargoType) : base(model, dateOfProduction, registrationNumber, fuelType, fuelConsumption, currentMileage, status, cargoType)
        {
            if (cargoType is null) 
            {
                throw new ArgumentNullException();
            }
            _cargoType = cargoType;
        }

        public double CalculateEnvironmentalImpact(double temperature, double temperatureFactor, string cargoType)
        {
            var EnvironmentalImpact = GetCargoTypeCost(_cargoType) +
                (temperatureFactor * temperature);

            return EnvironmentalImpact;
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
    }
}
