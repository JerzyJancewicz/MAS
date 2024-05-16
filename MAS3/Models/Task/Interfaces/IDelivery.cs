using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS3.Models.Task.Interfaces
{
    public interface IDelivery
    {
        public int CalculateIncome(DateTime deliveryDuration);
    }
}
