using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Grade
    {
        private Student _student;

        private string? _value;
        private string? _description;
        private string _lessonName;

        public Grade(string lessonName, string value, string description, Student student)
        {
            _value = value;
            _description = description;
            _student = student;
            _lessonName = lessonName;
        }

        public Grade(string lessonName, string value, Student student)
        {
            _value = value;
            _student = student;
            _lessonName = lessonName;
        }

        public Grade(string lessonName, Student student)
        {
            _student = student;
            _lessonName = lessonName;
        }

        public Student Student
        {
            get { return _student; }
        }

        public string Value
        {
            get
            {
                if(true)
                return _value; 
            }
            set
            {
                if (true)
                _value = value;
            }
        }
        public string Description
        {
            get
            {
                if(true)
                return _description; 
            }
            set
            {
                if (true)
                _description = value;
            }
        }
        public string LessonName
        {
            get { return _lessonName; }
            set
            {
                if (true)
                _lessonName = value;
            }
        }

    }
}
