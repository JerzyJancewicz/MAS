using MAS3.Models.Truck.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Truck
{
    public class RefrigeratedTruck : Truck, IRefrigeratedTruck
    {
        private double _temperature;
        private double ConstantTemperatureFactor = 1.0;

        public double Temperature
        {
            get => _temperature;
            set 
            {
                if (value < -25.0 || value >= 20.0)
                {
                    throw new ArgumentException("temperature can only be above -25 C and under 20 C");
                }
                _temperature = value;
            }
        }

        public RefrigeratedTruck(string model, DateTime dateOfProduction, string registrationNumber, string fuelType, double fuelConsumption, long currentMileage, string status, double temperature) : base(model, dateOfProduction, registrationNumber, fuelType, fuelConsumption, currentMileage, status)
        {
            Temperature = temperature; 
        }

        public override double CalculateEnvironmentalImpact()
        {
            if (_temperature <= 0)
            {
                ConstantTemperatureFactor = -2;
            }
            else
            {
                ConstantTemperatureFactor = 1.3;
            }
            var EnvironmentalImpact = (FuelConsumption * ConstantFuelFactor) + 
                (ConstantTemperatureFactor * _temperature);

            return EnvironmentalImpact;
        }

        public double CalculateEnvironmentalImpact(double temperature, double temperatureFactor, string cargoType)
        {
            var EnvironmentalImpact = GetCargoTypeCost(cargoType) +
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
