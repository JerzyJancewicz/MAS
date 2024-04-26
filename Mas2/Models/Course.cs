using Mas2.Validators;
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
            CourseValidator.ValidateTitle(title);
            CourseValidator.ValidateDescriptionNotNull(description);
            _title = title;
            _description = description;
        }

        public Course(string title)
        {
            CourseValidator.ValidateTitle(title);
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
                CourseValidator.ValidateTitle(_title);
                return _title;
            }
            set
            {
                CourseValidator.ValidateTitle(value);
                _title = value;
            }
        }

        public string Description
        {
            get
            {
                CourseValidator.ValidateDescriptionNotNull(_description);
                return _description ?? "";
            }
            set
            {
                CourseValidator.ValidateDescription(value);
                _description = value;
            }
        }

        public void AddLesson(Lesson lesson)
        {
            CourseValidator.ValidateLesson(lesson);
            _lessons.Add(lesson);
        }
        public void RemoveLesson(Lesson lesson)
        {
            CourseValidator.ValidateLesson(lesson);
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
