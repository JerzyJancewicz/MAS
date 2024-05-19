using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class ProductionRecord
    {
        private DateTime _startDate;
        private DateTime _endDate;

        private Product _product;
        private Machine _machine;

        public ProductionRecord(DateTime endDate, Product product, Machine machine)
        {
            _startDate = DateTime.UtcNow;
            _endDate = endDate;
            if (product ==null || machine == null)
            {
                throw new ArgumentNullException();
            }
            _product = product;
            _machine = machine;
        }
        public Product Product { get { return _product; } }
        public Machine Machine { get { return _machine; } }

        public void AddProductReference(Product product)
        {
            if (product == null) { throw new ArgumentNullException(); }
            _product = product;
        }
        public void AddMachineReference(Machine machine)
        {
            if (machine == null) { throw new ArgumentNullException(); }
            _machine = machine;
        }
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }
        public DateTime EndDate 
        {
            get => _endDate;
            set
            {
                if (value.Date < _startDate)
                {
                    throw new InvalidOperationException();
                }
                _endDate = value;
            }
        }
    }
}
