using Mas2.Validators;
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
            StudentValidator.ValidateName(name);
            StudentValidator.ValidateSurname(surname);
            _surname = surname;
            _name = name;
        }

        public Grade GetGradeByLessonName(string lessonName)
        {
            StudentValidator.ValidateGradesContainsLessonName(_grades ,lessonName);
            return _grades[lessonName];
        }

        public ReadOnlyCollection<Lesson> Lessons
        {
            get { return new ReadOnlyCollection<Lesson>(_lessons.ToList()); }
        }

        public string Name
        {
            get
            {
                StudentValidator.ValidateName(Name);
                return _name; 
            }
            set
            {
                StudentValidator.ValidateName(value);
                _name = value;
            }
        }
        public string Surname
        {
            get 
            {
                StudentValidator.ValidateSurname(_surname);
                return _surname; 
            }
            set
            {
                StudentValidator.ValidateSurname(value);
                _surname = value;
            }
        }

        public void AddGrade(Grade grade)
        {
            StudentValidator.ValidateSameLessonName(_grades, grade.LessonName);
            _grades.Add(grade.LessonName ,grade);
        }

        public void RemoveGrade(Grade grade)
        {
            StudentValidator.ValidateGrade(grade);
            _grades.Remove(grade.LessonName);
            grade.Student = null;
        }

        public void AddLesson(Lesson lesson)
        {
            StudentValidator.ValidateLesson(lesson);
            _lessons.Add(lesson);
            //lesson.AddStudent(this);
        }

        public void RemoveLesson(Lesson lesson)
        {
            StudentValidator.ValidateLesson(lesson);
            _lessons.Remove(lesson);
            //lesson.RemoveStudent(this);
        }
    }
}
