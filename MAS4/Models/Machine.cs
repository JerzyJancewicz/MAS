using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Machine
    {
        private string _type;
        private string _name;
        public Machine(string type, string name)
        {
            _type = type;
            _name = name;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("value can not be null");
        }
        public string Type
        {
            get => _type;
            set => _type = value ?? throw new ArgumentNullException("value can not be null");
        }
    }
}
