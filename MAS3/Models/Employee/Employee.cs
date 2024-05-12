using MAS3.Models.Employee;
using MAS3.Models.Employee.Intrefaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Person
{
    public class Employee : IDriver, IMechanic
    {
        private string _name = string.Empty;
        private string _surname = string.Empty;
        private int _age;
        public List<EmployeeRole> _employeeRoles = new List<EmployeeRole>();
        
        public string Name 
        {
            get => _name; 
            set => _name = value ?? throw new ArgumentNullException();
        }
        public string Surname
        {
            get => _surname;
            set => _surname = value ?? throw new ArgumentNullException();
        }
        public int Age
        {
            get => _age;
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _age = value;
            }
        }

        public Employee(string name, string surname, int age, List<EmployeeRole> employeeRoles)
        {
            Name = name;
            Surname = surname;
            Age = age;

            if (employeeRoles is null) 
            {
                throw new ArgumentNullException();
            }
            if (!employeeRoles.Any()) 
            {
                throw new ArgumentException();
            }
            _employeeRoles = employeeRoles;
        }

        public bool CalculateRaise(int AmmountOfRepairedVehicles)
        {
            if (_employeeRoles.Contains(EmployeeRole.MECHANIC)) 
            {
                throw new ArgumentException();
            }
            if (AmmountOfRepairedVehicles < 0) 
            {
                throw new ArgumentException();
            }
            return AmmountOfRepairedVehicles > 10;
        }

        public bool CheckDrivingCapability(double sobrietyLevel)
        {
            if (sobrietyLevel < 0) 
            {
                throw new ArgumentException();
            }
            if (_employeeRoles.Contains(EmployeeRole.DRIVER))
            {
                throw new ArgumentException();
            }
            return sobrietyLevel < 0.2;
        }
    }
}
