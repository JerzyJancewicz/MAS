using MP1.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1.models
{
    public class Address
    {
        public string _city;
        public string _street;
        public string City
        {
            get { return _city; }
            set
            {
                if (value.Length >= 3 && value is not null)
                {
                    _city = value;
                }
                else 
                {
                    new ArgumentException("city contains at least 3 characters");
                }
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                if (value.Length >= 3 && value is not null)
                {
                    _street = value;
                }
                else
                {
                    new ArgumentException("street contains at least 3 characters");
                }
            }
        }

        public Address(string street, string city)
        {
            ValidateAddress.Street(street);
            ValidateAddress.City(city);
            _street = street;
            _city = city;
        }
        public Address() { }
    }
}
