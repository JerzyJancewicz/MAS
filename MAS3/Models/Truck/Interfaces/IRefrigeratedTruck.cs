using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Truck.Interfaces
{
    public interface IRefrigeratedTruck
    {
        public double CalculateEnvironmentalImpact(double temperature, double temperatureFactor, string cargoType);
    }
}
