using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class StudentValidator
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
        public static void ValidateGradesContainsLessonName(Dictionary<string, Grade> grades, string lessonName)
        {
            if (grades == null)
            {
                throw new ArgumentNullException("Grades can not be null");
            }
            if (lessonName == null)
            {
                throw new ArgumentNullException("Lesson Name can not be null");
            }
            if (!grades.ContainsKey(lessonName))
            {
                throw new ArgumentException("There is no such a lesson name");
            }
            if (grades[lessonName] == null)
            {
                throw new ArgumentNullException("Grade can not be null");
            }
        }
        public static void ValidateSameLessonName(Dictionary<string, Grade> grades, string lessonName)
        {
            if (grades == null)
            {
                throw new ArgumentNullException("Grades can not be null");
            }
            if (lessonName == null)
            {
                throw new ArgumentNullException("Lesson Name can not be null");
            }
            if (grades.ContainsKey(lessonName))
            {
                throw new ArgumentException("There is already lesson Name on that name");
            }
        }
        public static void ValidateGrade(Grade? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
        }
        public static void ValidateLesson(Lesson? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
        }
    }
}
