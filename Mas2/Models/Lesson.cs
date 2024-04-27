﻿using Mas2.Validators;
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
        private Course? _course;
        private HashSet<Participation> _participations = new HashSet<Participation>();
        private HashSet<Student> _students = new HashSet<Student>();

        private string _topic;
        private int _duration; // in minutes 
        public Lesson(string topic, int duration, Course course)
        {
            LessonValidator.ValidateTopic(topic);
            LessonValidator.ValidateDuration(duration);
            LessonValidator.ValidateCourse(course);
            _topic = topic;
            _duration = duration;
            _course = course;

            _lessons.Add(this);
            _topics.Add(_topic);
            _course.AddLesson(this);
        }

        public static ReadOnlyCollection<Lesson> Lessons
        {
            get { return new ReadOnlyCollection<Lesson>(_lessons.ToList()); }
        }

        public static ReadOnlyCollection<string> Topics
        {
            get { return new ReadOnlyCollection<string>(_topics.ToList()); }
        }
        public Course? Course
        {
            get
            {
                LessonValidator.ValidateCourse(_course);
                return _course; 
            }
            set
            {
                _course = value; 
            }
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
            get
            {
                LessonValidator.ValidateTopic(_topic);
                return _topic;
            }
            set
            {
                LessonValidator.ValidateTopic(value);
                _topic = value; 
            }
        }
        public int Duration
        {
            get
            {
                LessonValidator.ValidateDuration(_duration);
                return _duration;
            }
            set
            {
                LessonValidator.ValidateDuration(value);
                _duration = value;
            }
        }

        public void AddStudent(Student student)
        {
            LessonValidator.ValidateStudent(student);
            _students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            LessonValidator.ValidateStudent(student);
            _students.Remove(student);
        }
        public void AddParticipation(Participation participation)
        {
            LessonValidator.ValidateParticipation(participation);
            _participations.Add(participation);
        }

        public void RemoveParticipation(Participation participation)
        {
            LessonValidator.ValidateParticipation(participation);
            if(participation.Teacher != null)
            {
                participation.Teacher.RemoveParticipation(participation);
            }
            participation.Teacher = null;
            participation.Lesson = null;
            _participations.Remove(participation);
        }
    }
}
