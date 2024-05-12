using MAS3.Models.Truck.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Truck
{
    public class DumpTruck : Truck
    {
        public double _stuffWeight;

        public double StuffWeight
        {
            get => _stuffWeight;
            set 
            {
                if(value < 0) 
                {
                    _stuffWeight = value;
                }
            }
        }

        public DumpTruck(string model, DateTime dateOfProduction, string registrationNumber, string fuelType, double fuelConsumption, long currentMileage, string status, double stuffWeight) : base(model, dateOfProduction, registrationNumber, fuelType, fuelConsumption, currentMileage, status)
        {
            StuffWeight = stuffWeight;
        }
        public override double CalculateEnvironmentalImpact()
        {
            var EnvironmentalImpact = (FuelConsumption * ConstantFuelFactor) +
                (StuffWeight * 3);

            return EnvironmentalImpact;
        }
    }
}
