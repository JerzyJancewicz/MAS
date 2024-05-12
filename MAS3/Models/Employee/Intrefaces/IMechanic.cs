using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Employee.Intrefaces
{
    public interface IMechanic
    {
        public bool CalculateRaise(int AmmountOfRepairedVehicles);
    }
}
