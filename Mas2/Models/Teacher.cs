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
            get { return _name; }
            set
            {
                if(true)
                _name = value; 
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (true)
                    _surname = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (true)
                    _email = value;
            }
        }

        public void AddParticipation(Participation participation)
        {
            _participations.Add(participation);
        }

        public void RemoveParticipation(Participation participation)
        {
            _participations.Remove(participation);
            participation.Teacher = null;
        }
    }
}
