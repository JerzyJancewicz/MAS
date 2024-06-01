using MAS4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas4Tests
{
    public class WorkerTeamAssociationsTest
    {
        public class WorkerTeamTests
        {
            [Fact]
            public void AddAssignedTeam_AssignsTeamToWorker()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                worker.AddAssignedTeam(team);

                Assert.Contains(team, worker.AssignedTeams);
                Assert.Contains(worker, team.AssignedWorkers);
            }

            [Fact]
            public void AddManagingTeam_AssignsManagerToTeam()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                worker.AddAssignedTeam(team);
                worker.AddManagingTeam(team);

                Assert.Contains(team, worker.ManagedTeams);
                Assert.Contains(worker, team.ManagingWorkers);
            }

            [Fact]
            public void RemoveAssignedTeam_RemovesTeamFromWorker()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                worker.AddAssignedTeam(team);
                worker.RemoveAssignedTeam(team);

                Assert.DoesNotContain(team, worker.AssignedTeams);
                Assert.DoesNotContain(worker, team.AssignedWorkers);
            }

            [Fact]
            public void RemoveManagingTeam_RemovesManagerFromTeam()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                worker.AddAssignedTeam(team);
                worker.AddManagingTeam(team);
                worker.RemoveManagingTeam(team);

                Assert.DoesNotContain(team, worker.ManagedTeams);
                Assert.DoesNotContain(worker, team.ManagingWorkers);
            }

/*            [Fact]
            public void AddManager_AssignsManagerToWorker()
            {
                var worker = new Worker("John", "Doe");
                var manager = new Manager("Jane");

                worker.AddManager(manager);

                Assert.Equal(manager, worker.Manager);
                Assert.Contains(worker, manager.Workers);
            }

            [Fact]
            public void RemoveManager_RemovesManagerFromWorker()
            {
                var worker = new Worker("John", "Doe");
                var manager = new Manager("Jane");

                worker.AddManager(manager);
                worker.RemoveManager();

                Assert.Null(worker.Manager);
                Assert.DoesNotContain(worker, manager.Workers);
            }
*/
            [Fact]
            public void AssignWorker_AssignsWorkerToTeam()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                team.AssignWorker(worker);

                Assert.Contains(team, worker.AssignedTeams);
                Assert.Contains(worker, team.AssignedWorkers);
            }

            [Fact]
            public void RemoveWorker_RemovesWorkerFromTeam()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                team.AssignWorker(worker);
                team.RemoveWorker(worker);

                Assert.DoesNotContain(team, worker.AssignedTeams);
                Assert.DoesNotContain(worker, team.AssignedWorkers);
            }

            [Fact]
            public void AssignManager_AssignsManagerToTeam()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                team.AssignWorker(worker);
                team.AssignManager(worker);

                Assert.Contains(team, worker.ManagedTeams);
                Assert.Contains(worker, team.ManagingWorkers);
            }

            [Fact]
            public void RemoveManager_RemovesManagerFromTeam()
            {
                var worker = new Worker("John", "Doe");
                var team = new Team("Team A");

                team.AssignWorker(worker);
                team.AssignManager(worker);
                team.RemoveManager(worker);

                Assert.DoesNotContain(team, worker.ManagedTeams);
                Assert.DoesNotContain(worker, team.ManagingWorkers);
            }
        }
    }
}
