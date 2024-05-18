using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Team
    {
        private string _teamName;

        private HashSet<Worker> _assignedWorkers = new HashSet<Worker>();
        private HashSet<Worker> _managingWorkers = new HashSet<Worker>();

        public Team(string teamName)
        {
            _teamName = teamName;
        }
        public string TeamName
        {
            get { return _teamName;}
            set { _teamName = value ?? throw new ArgumentException("value can not be null"); }
        }
        public HashSet<Worker> AssignedWorkers 
        {
            get => _assignedWorkers;
        }
        public HashSet<Worker> ManagingWorkers
        {
            get => _managingWorkers;
        }
        public void AssignWorker(Worker worker)
        {
            if (worker == null){ throw new ArgumentNullException("value can not be null"); }
            _assignedWorkers.Add(worker);
            worker.AssignedTeams.Add(this);
        }

        public void RemoveWorker(Worker worker)
        {
            if (worker == null) { throw new ArgumentNullException("value can not be null"); }
            if (_managingWorkers.Contains(worker))
            {
                _managingWorkers.Remove(worker);
                worker.ManagedTeams.Remove(this);
            }
            _assignedWorkers.Remove(worker);
            worker.AssignedTeams.Remove(this);
        }

        public void AssignManager(Worker worker)
        {
            if (worker == null) { throw new ArgumentNullException("value can not be null"); }
            if (!_assignedWorkers.Contains(worker))
            {
                throw new InvalidOperationException("Worker must be assigned to the team before being a manager");
            }
            _managingWorkers.Add(worker);
            worker.ManagedTeams.Add(this);
        }

        public void RemoveManager(Worker worker)
        {
            if (worker == null) { throw new ArgumentNullException("value can not be null"); }
            if (_managingWorkers.Contains(worker))
            {
                _managingWorkers.Remove(worker);
                worker.ManagedTeams.Remove(this);
            }
        }
    }
}
