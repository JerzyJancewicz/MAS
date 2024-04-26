using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Student
    {
        // name of the lesson is qualifier here
        private Dictionary<string, Grade> _grades = new Dictionary<string, Grade>();
        private HashSet<Lesson> _lessons = new HashSet<Lesson>();

        private string _name;
        private string _surname;

        public Student(string surname, string name)
        {
            _surname = surname;
            _name = name;
        }

        public Grade GetGradeByLessonName(string lessonName)
        {
            // lesson Name is null
            // there is no such a lesson name
            //if(true)
            return _grades[lessonName];
        }

        public ReadOnlyCollection<Lesson> Lessons
        {
            get { return new ReadOnlyCollection<Lesson>(_lessons.ToList()); }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (true)
                _name = value;
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (true)
                _surname = value;
            }
        }

        public void AddGrade(Grade grade)
        {
            // modify that grade.LessonName can not be the same
            _grades.Add(grade.LessonName ,grade);
        }

        public void RemoveGrade(Grade grade)
        {
            _grades.Remove(grade.LessonName);
            grade.Student = null;
        }

        public void AddLesson(Lesson lesson)
        {
            _lessons.Add(lesson);
            lesson.AddStudent(this);
        }

        public void RemoveLesson(Lesson lesson)
        {
            _lessons.Remove(lesson);
            lesson.RemoveStudent(this);
        }
    }
}
