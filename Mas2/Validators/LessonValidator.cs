using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class LessonValidator
    {
        public static void ValidateTopic(string? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
            if (value.Split().Length < 2 && value.Split().Length > 20)
            {
                throw new ArgumentException("Topic contains at least 3 letters and maximum amount of 20");
            }
        }
        public static void ValidateDuration(int? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Duration can not be null");
            }
            if (value < 0 && value > 180)
            {
                throw new ArgumentException("Duration contains at least 3 letters and maximum amount of 6");
            }
        }
        public static void ValidateStudent(Student? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Student can not be null");
            }
        }
        public static void ValidateParticipation(Participation? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Participation can not be null");
            }
        }
        public static void ValidateCourse(Course? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Course can not be null");
            }
        }
    }
}
