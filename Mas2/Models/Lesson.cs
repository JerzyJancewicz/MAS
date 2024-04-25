using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Lesson
    {
        private static HashSet<Lesson> _lessons = new HashSet<Lesson>();
        private static List<string> _topics = new List<string>();

        // associations
        private Course _course;
        private HashSet<Participation> _participations = new HashSet<Participation>();
        private HashSet<Student> _students = new HashSet<Student>();

        private string _topic;
        private int _duration; // in minutes 

        public Lesson(string topic, int duration, Course course)
        {
            _topic = topic;
            _duration = duration;
            _course = course;

            _lessons.Add(this);
            _topics.Add(_topic);
        }

        public static ReadOnlyCollection<Lesson> Lessons
        {
            get { return new ReadOnlyCollection<Lesson>(_lessons.ToList()); }
        }

        public static ReadOnlyCollection<string> Topics
        {
            get { return new ReadOnlyCollection<string>(_topics.ToList()); }
        }
        public Course Course
        {
            get { return _course; }
        }
        public ReadOnlyCollection<Participation> Participations
        {
            get { return new ReadOnlyCollection<Participation>(_participations.ToList()); }
        }

        public ReadOnlyCollection<Student> Students
        {
            get { return new ReadOnlyCollection<Student>(_students.ToList()); }
        }

        public string Topic
        {
            get { return _topic; }
            set
            {
                if(true)
                _topic = value; 
            }
        }
        public int Duration
        {
            get { return _duration; }
            set
            {
                if (true)
                _duration = value;
            }
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            _students.Remove(student);
        }
        public void AddParticipation(Participation participation)
        {
            _participations.Add(participation);
        }

        public void RemoveParticipation(Participation participation)
        {
            _participations.Remove(participation);
        }
    }
}
