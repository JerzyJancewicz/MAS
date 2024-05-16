using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Product
    {
        private string _serialNumber;
        private string _name;
        private double _price;

        private static HashSet<string> serialNumbers = new HashSet<string>();
        private static readonly int MAX_NAME_LENGTH = 50;
        private static readonly double MAX_PRICE_CHANGE = 1.2;

        public Product(string serialNumber, string name, double price)
        {
            _serialNumber = serialNumber;
            _name = name;
            _price = price;

            serialNumbers.Add(serialNumber);
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name can not be null");
                }
                if (value.Length > MAX_NAME_LENGTH)
                {
                    throw new ArgumentException("Name length is over 50 characters");
                }
                _name = value;
            }
        }

        public double Price
        {
            get => _price;
            set 
            {
                if (value > _price * MAX_PRICE_CHANGE)
                {
                    throw new ArgumentException("Price can not be over " + MAX_PRICE_CHANGE + " times previous value");
                }
                _price = value;
            }
        }

        public string SerialNumber
        {
            get => _serialNumber;
            set 
            {
                if (serialNumbers.Contains(value))
                {
                    throw new ArgumentException("Value already exists");
                }
                serialNumbers.Remove(_serialNumber);
                _serialNumber = value;
                serialNumbers.Add(_serialNumber);
            }
        }
        public static ReadOnlyCollection<string> SerialNumbers
        {
            get => new ReadOnlyCollection<string>(serialNumbers.ToList());
        }
    }
}
