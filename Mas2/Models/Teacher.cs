using Mas2.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Teacher
    {
        private HashSet<Participation> _participations = new HashSet<Participation>();

        private string _name;
        private string _surname;
        private string _email;

        public Teacher(string name, string surname, string email)
        {
            TeacherValidator.ValidateName(name);
            TeacherValidator.ValidateSurname(surname);
            TeacherValidator.ValidateEmail(email);
            _name = name;
            _surname = surname;
            _email = email;
        }

        public ReadOnlyCollection<Participation> Participations
        {
            get { return new ReadOnlyCollection<Participation>(_participations.ToList()); }
        }

        public string Name
        {
            get
            {
                TeacherValidator.ValidateName(_name);
                return _name;
            }
            set
            {
                TeacherValidator.ValidateName(value);
                _name = value; 
            }
        }
        public string Surname
        {
            get
            {
                TeacherValidator.ValidateSurname(_surname);
                return _surname; 
            }
            set
            {
                TeacherValidator.ValidateSurname(value);
                _surname = value;
            }
        }
        public string Email
        {
            get
            {
                TeacherValidator.ValidateEmail(_email);
                return _email; 
            }
            set
            {
                TeacherValidator.ValidateEmail(value);
                _email = value;
            }
        }

        public void AddParticipation(Participation participation)
        {
            TeacherValidator.ValidateParticipation(participation);
            if (!_participations.Contains(participation)) 
            {
                _participations.Add(participation);
                participation.AddTeacher(this);
            }
        }

        public void RemoveParticipation(Participation participation)
        {
            TeacherValidator.ValidateParticipation(participation);
            if (_participations.Contains(participation))
            {
                _participations.Remove(participation);
                participation.RemoveTeacher();

                participation.Lesson?.RemoveParticipation(participation);
                participation.RemoveLesson();
            }
        }
    }
}
