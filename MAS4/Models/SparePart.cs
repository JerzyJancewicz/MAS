using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class SparePart
    {
        private string _name;
        public double Weight { get; set; }
        public double Price { get; set; }

        private List<Machine> _machines = new List<Machine>();
        public SparePart(string name, double weight, double price)
        {
            _name = name;
            Price = price;
            Weight = weight;
        }

        public void RemoveMachine(Machine machine) 
        {
            if (machine == null) { throw new ArgumentNullException(); }
            _machines.Remove(machine);
        }

        public List<Machine> Machines
        {
            get => _machines;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }
    }
}
