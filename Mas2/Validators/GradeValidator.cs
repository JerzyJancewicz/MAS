using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class GradeValidator
    {
        public static void ValidateLessonName(string? lessonName)
        {
            if (lessonName == null)
            {
                throw new ArgumentNullException("LessonName can not be null");
            }
            if (lessonName.Split().Length < 2 && lessonName.Split().Length > 20)
            {
                throw new ArgumentException("LessonName contains at least 3 letters and maximum amount of 20");
            }
        }
        public static void ValidateValue(string? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value can not be null");
            }
            if (value.Split().Length < 2 && value.Split().Length > 6)
            {
                throw new ArgumentException("Value contains at least 3 letters and maximum amount of 6");
            }
        }
        public static void ValidateDescription(string? description)
        {
            if (description == null)
            {
                throw new ArgumentNullException("Description can not be null");
            }
            if (description.Split().Length < 2 && description.Split().Length > 200)
            {
                throw new ArgumentException("Description contains at least 3 letters and maximum amount of 200");
            }
        }
        public static void ValidateStudent(Student? student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student can not be null");
            }
        }
    }
}
