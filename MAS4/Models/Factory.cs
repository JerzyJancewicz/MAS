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

        private List<Machine> machines = new List<Machine>();
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
        public List<Machine> Machines 
        {
            get => machines;
        }

        public void AddMachine(Machine machine)
        {
            if (machine == null) { throw new ArgumentNullException("value can not be null"); }
            machines.Add(machine);
            machines.Sort((x, y) => x.Name.CompareTo(y.Name));
        }
        public void RemoveMachine(Machine machine)
        {
            if (machine == null) { throw new ArgumentNullException("value can not be null"); }
            machines.Remove(machine);
        }
    }
}
