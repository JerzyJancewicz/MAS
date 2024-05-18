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

        private HashSet<Worker> AssignedWorkers = new HashSet<Worker>();
        private HashSet<Worker> ManagedWorkers = new HashSet<Worker>();

        public Team(string teamName)
        {
            if (teamName == null)
            {
                throw new ArgumentNullException();
            }
            _teamName = teamName;
        }
        public string TeamName
        {
            get { return _teamName;}
            set { _teamName = value ?? throw new ArgumentException("value can not be null"); }
        }
    }
}
