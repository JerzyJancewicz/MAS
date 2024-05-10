using Mas2.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Grade
    {
        private Student? _student;

        private string? _value;
        private string? _description;
        private string _lessonName;

        public Grade(string lessonName, string value, string description, Student student)
        {
            GradeValidator.ValidateLessonName(lessonName);
            GradeValidator.ValidateValue(value);
            GradeValidator.ValidateDescription(description);
            GradeValidator.ValidateStudent(student);

            _value = value;
            _description = description;
            _student = student;
            _lessonName = lessonName;

            _student.AddGrade(this);
        }

        public Grade(string lessonName, string value, Student student)
        {
            GradeValidator.ValidateLessonName(lessonName);
            GradeValidator.ValidateValue(value);
            GradeValidator.ValidateStudent(student);

            _value = value;
            _student = student;
            _lessonName = lessonName;

            _student.AddGrade(this);
        }

        public Grade(string lessonName, Student student)
        {
            GradeValidator.ValidateLessonName(lessonName);
            GradeValidator.ValidateStudent(student);

            _student = student;
            _lessonName = lessonName;

            _student.AddGrade(this);
        }

        // BŁĄD !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Student? Student
        {
            get
            {
                GradeValidator.ValidateStudent(_student);
                return _student; 
            }
            set
            {
                _student = value; 
            }
        }

        public string Value
        {
            get
            {
                GradeValidator.ValidateValue(_value);
                return _value ?? "dst"; 
            }
            set
            {
                GradeValidator.ValidateValue(value);
                _value = value;
            }
        }
        public string Description
        {
            get
            {
                GradeValidator.ValidateDescription(_description);
                return _description ?? ""; 
            }
            set
            {
                GradeValidator.ValidateDescription(value);
                _description = value;
            }
        }
        public string LessonName
        {
            get
            {
                GradeValidator.ValidateLessonName(_lessonName);
                return _lessonName; 
            }
            set
            {
                GradeValidator.ValidateLessonName(value);
                _lessonName = value;
            }
        }
    }
}
