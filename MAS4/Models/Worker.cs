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
            manager.AddWorker(this);
        }
        public void RemoveManager()
        {
            if (_manager != null)
            {
                _manager.RemoveWorker(this);
            }
            _manager = null;
        }
        public void AddAssignedTeam(Team team) 
        {
            if (team == null) { throw new ArgumentNullException("value can not be null"); }
            if (!_assignedTeams.Contains(team))
            {
                _assignedTeams.Add(team);
                team.AssignWorker(this);
            }
        }
        public void AddManagingTeam(Team team)
        {
            if (team == null) { throw new ArgumentNullException("value can not be null"); }
            if (!_assignedTeams.Contains(team))
            {
                throw new InvalidOperationException("Worker must be assigned to the team before being a manager");
            }
            if (!_managedTeams.Contains(team))
            {
                _managedTeams.Add(team);
                team.AssignManager(this);
            }
        }
        public void RemoveAssignedTeam(Team team)
        {
            if (team == null) { throw new ArgumentNullException("value can not be null"); }
            if (_assignedTeams.Contains(team))
            {
                _assignedTeams.Remove(team);
                team.RemoveWorker(this);
                _managedTeams.Remove(team);
                team.RemoveManager(this);
            }
        }
        public void RemoveManagingTeam(Team team)
        {
            if (team == null) { throw new ArgumentNullException("value can not be null"); }
            if (_managedTeams.Contains(team))
            {
                _managedTeams.Remove(team);
                team.RemoveManager(this);
            }
        }
        public Manager Manager
        {
            get => _manager!;
            private set => _manager = value;
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
