using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Factory
    {
        private string _factoryName;
        private string _location;

        private HashSet<Machine> machines = new HashSet<Machine>();
        public Factory(string factoryName, string location)
        {
            _factoryName = factoryName;
            _location = location;
        }

        public string FactoryName 
        {
            get => _factoryName;
            set => _factoryName = value ?? throw new ArgumentNullException("value can not be null");
        }
        public string Location 
        {
            get => _location;
            set => _location = value ?? throw new ArgumentNullException("value can not be null");
        }
        public HashSet<Machine> Machines 
        {
            get => machines;
        }

        public void AddMachine(Machine machine)
        {
            if (machine == null) { throw new ArgumentNullException("value can not be null"); }
            if (!machines.Contains(machine))
            {
                machines.Add(machine);
                machines.ToList().Sort((x, y) => x.Name.CompareTo(y.Name));
                machine.AddFactory(this);
            }
        }
        public void RemoveMachine(Machine machine)
        {
            if (machine == null) { throw new ArgumentNullException("value can not be null"); }
            if (machines.Contains(machine)) 
            {
                machines.Remove(machine);
                machine.RemoveFactory();
            }
        }
    }
}
