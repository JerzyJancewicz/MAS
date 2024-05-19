using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Worker
    {
        private string _name;
        private string _surname;

        private HashSet<Team> _assignedTeams = new HashSet<Team>();
        private HashSet<Team> _managedTeams = new HashSet<Team>();
        private Manager? _manager;

        public Worker(string name, string surname)
        {
            if (name == null || surname == null)
            {
                throw new ArgumentNullException("value can not be null");
            }
            _name = name;
            _surname = surname;
        }
        public void AddManager(Manager manager)
        {
            if (manager == null) { throw new ArgumentNullException(); }
            _manager = manager;
        }
        public void RemoveManager()
        {
            _manager = null;
        }
        public Manager Manager
        {
            get => _manager;
        }
        public HashSet<Team> AssignedTeams
        {
            get => _assignedTeams;

        }
        public HashSet<Team> ManagedTeams
        {
            get => _managedTeams;
        }
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("value can not be null");
        }
        public string Surname
        {
            get => _surname;
            set => _surname = value ?? throw new ArgumentNullException("value can not be null");
        }
    }
}
