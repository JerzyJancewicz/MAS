using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class CourseValidator
    {
        public static void ValidateTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Lesson can not be null");
            }
            if (title.Split().Length < 2 && title.Split().Length > 20)
            {
                throw new ArgumentException("Title contains at least 3 letters and maximum amount of 20");
            }
        }
        public static void ValidateDescriptionNotNull(string? description)
        {
            if (description == null)
            {
                throw new ArgumentNullException("Lesson can not be null");
            }
            if (description.Split().Length > 200)
            {
                throw new ArgumentException("Description contains maximum amount of 200 letters");
            }
        }
        public static void ValidateDescription(string description)
        {
            if (description.Split().Length > 200)
            {
                throw new ArgumentException("Description contains maximum amount of 200 letters");
            }
        }
        public static void ValidateLesson(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException("Lesson can not be null");
            }
        }
    }
}
