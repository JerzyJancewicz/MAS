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
                ParticipationValidator.ValidateTeacher(_teacher);
                return _teacher;
            }
            set
            {
                _teacher = value; 
            }
        }
        public Lesson? Lesson
        {
            get
            {
                ParticipationValidator.ValidateLesson(_lesson);
                return _lesson;
            } 
            set
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
    }
}
