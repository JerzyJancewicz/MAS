using Mas2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class TeacherValidator
    {
        public static void ValidateName(string? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Name can not be null");
            }
            if (value.Split().Length < 2 && value.Split().Length > 20)
            {
                throw new ArgumentException("Name contains at least 3 letters and maximum amount of 20");
            }
        }
        public static void ValidateSurname(string? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Surname can not be null");
            }
            if (value.Split().Length < 2 && value.Split().Length > 20)
            {
                throw new ArgumentException("Surname contains at least 3 letters and maximum amount of 20");
            }
        }
        public static void ValidateEmail(string? value)
        {
            var regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            if (value is not null)
            {
                if (!regex.IsMatch(value))
                {
                    throw new ValidationException("No valid email");
                }
            }
        }
        public static void ValidateParticipation(Participation? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Participation can not be null");
            }
        }
    }
}
