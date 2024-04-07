using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MP1.Validators
{
    public class ValidateClient
    {
        public static void Name(string name)
        {
            if (name.Length < 3 && name is null)
            {
                new ArgumentException("name contains at least 3 characters");
            }
        }

        public static void Surname(string surname)
        {
            if (surname.Length < 3 && surname is null)
            {
                new ArgumentException("surname contains at least 3 characters");
            }
        }

        public static void PhoneNumbersList(string phoneNumber, List<string> phoneNumbers)
        {
            if (phoneNumbers.Count == 1)
            {
                new ArgumentException("You cannot remove this number from the list");
            }

            var tmp = phoneNumbers.FirstOrDefault(e => e.Equals(phoneNumber));
            if (tmp is null || tmp.Count() == 0)
            {
                new ArgumentException("There is no such a number in phone Numbers");
            }
        }

        public static void PhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length < 9 || phoneNumber is null)
            {
                new ArgumentException("Phone Number contains at least 9 characters");
            }
        }

        public static void Email(string? email)
        {
            var regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            if (email is not null)
            {
                if (!regex.IsMatch(email))
                {
                    throw new ValidationException("No valid email");
                }
            }
        }
    }
}
