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
        public int Ammount { get; set; }
        public double Price { get; set; }

        private HashSet<Machine> _machines = new HashSet<Machine>();
        public SparePart(string name, double weight, double price, int ammount)
        {
            if (name == null) { throw new ArgumentNullException(); }
            _name = name;
            Price = price;
            Weight = weight;
            Ammount = ammount;
        }
        public void AddMachine(Machine machine) 
        {
            if (machine == null) { throw new ArgumentNullException(); }
            if (!_machines.Contains(machine)) 
            {
                _machines.Add(machine);
                machine.AddSparePart(this);
            }
        }

        public void RemoveMachine(Machine machine) 
        {
            if (machine == null) { throw new ArgumentNullException(); }
            if (_machines.Contains(machine))
            {
                _machines.Remove(machine);
                machine.RemoveSparePart(this);
            }
        }

        public HashSet<Machine> Machines
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
