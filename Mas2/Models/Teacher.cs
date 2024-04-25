using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Teacher
    {
        private HashSet<Participation> Participations = new HashSet<Participation>();

        private string Name;
        private string Surname;
        private string Email;

        public Teacher(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
