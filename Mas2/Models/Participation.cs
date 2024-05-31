using Mas2.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Participation
    {
        private Lesson? _lesson;
        private Teacher? _teacher;

        private DateTime _date;
        private string _status;

        public Participation(Teacher teacher, Lesson lesson, string status, DateTime date)
        {
            ParticipationValidator.ValidateTeacher(teacher);
            ParticipationValidator.ValidateLesson(lesson);
            ParticipationValidator.ValidateStatus(status);
            ParticipationValidator.ValidateDate(date);

            _lesson = lesson;
            _teacher = teacher;
            _status = status;
            _date = date;

            _teacher.AddParticipation(this);
            _lesson.AddParticipation(this);
        }

        public Teacher? Teacher
        {
            get
            {
                return _teacher;
            }
            private set
            {
                _teacher = value; 
            }
        }

        public Lesson? Lesson
        {
            get
            {
                return _lesson;
            } 
            private set
            {
                _lesson = value;
            }
        }

        public DateTime Date
        {
            get
            {
                ParticipationValidator.ValidateDate(_date);
                return _date; 
            }
            set
            {
                ParticipationValidator.ValidateDate(_date);
                _date = value; 
            }
        }
        public string Status
        {
            get
            {
                ParticipationValidator.ValidateStatus(_status);
                return _status; 
            } 
            set
            {
                ParticipationValidator.ValidateStatus(_status);
                _status = value; 
            }
        }

        public void RemoveTeacher()
        {
            if(_teacher != null)
            _teacher.RemoveParticipation(this);
            _teacher = null;
        }
        public void AddTeacher(Teacher teacher)
        {
            ParticipationValidator.ValidateTeacher(teacher);
            _teacher = teacher;
            teacher.AddParticipation(this);
        }
        public void RemoveLesson()
        {
            if (_lesson != null)
            _lesson.RemoveParticipation(this);
            _lesson = null;
        }
        public void AddLesson(Lesson lesson)
        {
            ParticipationValidator.ValidateLesson(lesson);
            lesson.AddParticipation(this);
            _lesson = lesson;
        }
    }
}
