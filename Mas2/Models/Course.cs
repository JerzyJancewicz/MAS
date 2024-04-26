using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Course
    {
        private HashSet<Lesson> _lessons = new HashSet<Lesson>();
        private string _title;
        private string? _description;

        public Course(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public Course(string title)
        {
            _title = title;
        }

        public ReadOnlyCollection<Lesson> Lessons
        {
            get { return new ReadOnlyCollection<Lesson>(_lessons.ToList()); }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if(true)
                _title = value;
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
                if(true)
                _description = value;
            }
        }

        public void AddLesson(Lesson lesson)
        {
            _lessons.Add(lesson);
        }
        public void RemoveLesson(Lesson lesson)
        {
            foreach(var student in lesson.Students.ToList())
            {
                student.RemoveLesson(lesson);
            }

            foreach (var participation in lesson.Participations.ToList())
            {
                lesson.RemoveParticipation(participation);
            }

            lesson.Course = null;
            _lessons.Remove(lesson);
        }
    }
}
