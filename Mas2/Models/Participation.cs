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
        private Lesson _lesson;
        private Teacher _teacher;

        private DateTime _date;
        private string _status;

        public Participation(Teacher teacher, Lesson lesson, string status, DateTime date)
        {
            _lesson = lesson;
            _teacher = teacher;
            _status = status;
            _date = date;
        }

        /*public ReadOnlyCollection<Lesson> Lessons
        {
            get { return new ReadOnlyCollection<Lesson>(_lessons.ToList()); }
        }*/

        public Teacher Teacher
        {
            get { return _teacher; }
        }
        public Lesson Lesson
        {
            get { return _lesson; } 
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if(true)
                _date = value; 
            }
        }

        public string Status
        {
            get { return _status; } 
            set
            {
                if(true)
                _status = value; 
            }
        }
        /*public void AddLesson(Lesson lesson)
        {
            _lessons.Add(lesson);
        }

        public void RemoveLesson(Lesson lesson)
        {
            _lessons.Remove(lesson);
        }*/
    }
}
