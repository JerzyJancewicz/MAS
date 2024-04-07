using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1.Validators
{
    public class ValidateAddress
    {
        public static void City(string city)
        {
            if (city.Length < 3 || city is null)
            {
                new ArgumentException("city contains at least 3 characters");
            }
        }

        public static void Street(string street)
        {
            if (street.Length < 3 || street is null)
            {
                new ArgumentException("street contains at least 3 characters");
            }
        }
    }
}
