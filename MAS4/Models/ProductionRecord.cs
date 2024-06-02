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

        private Product? _product;
        private Machine? _machine;

        private bool _isRemovingProduct = false;
        private bool _isRemovingMachine = false; 

        public ProductionRecord(DateTime endDate, Product product, Machine machine)
        {
            _startDate = DateTime.UtcNow;
            _endDate = endDate;
            if (product == null || machine == null)
            {
                throw new ArgumentNullException();
            }
            _product = product;
            _machine = machine;
            
        }

        public void AddProductReference(Product product)
        {
            if (product == null) { throw new ArgumentNullException(); }
            _product = product;
            product.AddProductionRecord(this);
        }
        public void AddMachineReference(Machine machine)
        {
            if (machine == null) { throw new ArgumentNullException(); }
            _machine = machine;
            machine.AddProductionRecord(this);
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
        public void RemoveProductReference()
        {
            if (_product != null && !_isRemovingProduct)
            {
                _isRemovingProduct = true;
                var tempProduct = _product;
                _product = null;
                tempProduct.RemoveProductionRecord(this);
                _isRemovingProduct = false;
            }
        }

        public void RemoveMachineReference()
        {
            if (_machine != null && !_isRemovingMachine)
            {
                _isRemovingMachine = true;
                var tempMachine = _machine;
                _machine = null;
                tempMachine.RemoveProductionRecord(this);
                _isRemovingMachine = false;
            }
        }
        public Product Product
        { 
            get { return _product!; }
            private set { _product = value; }
        }
        public Machine Machine 
        {
            get { return _machine!; }
            set => _machine = value;
        }
    }
}
