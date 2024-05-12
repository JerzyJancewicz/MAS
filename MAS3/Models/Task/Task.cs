using MAS3.Models.Employee;
using MAS3.Models.Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Task
{
    public class Task : IBring, IDelivery
    {
        private string _name;
        private string _description; 
        private TaskRole _role;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();   
        }
        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException();
        }
        public TaskRole Role
        {
            get => _role;
            set => _role = value;
        }
        public Task(string name, string description, TaskRole role)
        {
            Name = name;
            Description = description;
            _role = role;
        }
        public int CalculateIncome(DateTime deliveryDuration)
        {
            if (_role != TaskRole.DELIVERY)
            {
                throw new InvalidOperationException();
            }

            TimeSpan twoDays = TimeSpan.FromDays(2);

            if (deliveryDuration < DateTime.Now - twoDays)
            {
                return 2;
            }
            return 1;
        }

        public double CalculateOutcome(int stuffAmount, int luxuryFactor)
        {
            if (_role != TaskRole.BRING)
            {
                throw new InvalidOperationException();
            }
            if (stuffAmount < 0 || luxuryFactor < 0)
            {
                throw new ArgumentException();
            }

            return stuffAmount * luxuryFactor;
        }
    }
}
