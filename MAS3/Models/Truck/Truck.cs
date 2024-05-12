using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Truck
{
    public abstract class Truck
    {
        private string _model = string.Empty;
        private DateTime _dateOfProduction;
        private string _registrationNumber = string.Empty;
        private string _fuelType = string.Empty;
        private double _fuelConsumption;
        private double _constantFuelFactor;
        private long _currentMileage;
        private string _status = string.Empty;

        protected double GasolineCost = 6.50;
        protected double DieselCost = 6.70;

        public string Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime DateOfProduction
        {
            get => _dateOfProduction;
            private set => _dateOfProduction = value;
        }

        public string RegistrationNumber
        {
            get => _registrationNumber;
            set => _registrationNumber = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string FuelType
        {
            get => _fuelType;
            private set => _fuelType = value;
        }

        public double FuelConsumption
        {
            get => _fuelConsumption;
            set 
            {
                if (_fuelConsumption > 0)
                {
                    _fuelConsumption = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("fuel consumption can not be below 0");
                }
            }
        }

        public double ConstantFuelFactor
        {
            get => _constantFuelFactor;
            set => _constantFuelFactor = value;
        }

        public long CurrentMileage
        {
            get => _currentMileage;
            set 
            {
                if (_currentMileage < value)
                {
                    _currentMileage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("new current mileage can not be below current mileage");
                }
            } 
        }

        public string Status
        {
            get => _status;
            set => _status = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Truck(string model, DateTime dateOfProduction, string registrationNumber, string fuelType, double fuelConsumption, long currentMileage, string status)
        {
            Model = model;
            DateOfProduction = dateOfProduction;
            RegistrationNumber = registrationNumber;
            FuelType = fuelType;
            FuelConsumption = fuelConsumption;
            CurrentMileage = currentMileage;
            Status = status;

            ConstantFuelFactor = CalculateConstantFuelFactor();
        }
        private double CalculateConstantFuelFactor() { 
            switch (FuelType.ToLower())
            {
                case "gasoline":
                    return 1.1;
                case "diesel":
                    return 2.5;
                default: return 1.1;
            }
        }
        public abstract double CalculateEnvironmentalImpact();
    }
}
