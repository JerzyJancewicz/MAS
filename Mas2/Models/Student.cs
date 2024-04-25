using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Student
    {
        // name of the lesson is qualifier here
        Dictionary<string, Grade> Grades = new Dictionary<string, Grade>();
        private Grade Grade;
        private HashSet<Lesson> Lessons = new HashSet<Lesson>();

        private static int NextId;
        private int Id;
        private string Name;
        private string Surname;
        private string LessonName;
        public Student(string surname, string name, string lessonName, Grade grade)
        {
            Surname = surname;
            Name = name;
            Grade = grade;
            LessonName = lessonName;
        }
    }
}
