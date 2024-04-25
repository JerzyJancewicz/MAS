using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Grade
    {
        private Student Student;

        private string? Value;
        private string? Description;
        private string LessonName;

        public Grade(string lessonName, string value, string description, Student student)
        {
            Value = value;
            Description = description;
            Student = student;
            LessonName = lessonName;
        }

        public Grade(string lessonName, string value, Student student)
        {
            Value = value;
            Student = student;
            LessonName = lessonName;
        }

        public Grade(string lessonName, Student student)
        {
            Student = student;
            LessonName = lessonName;
        }
    }
}
