using MAS4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas4Tests
{
    public class MachineFactoryAssociationsTest
    {
        public class MachineFactoryTests
        {
            [Fact]
            public void AddMachine_AssignsMachineToFactory()
            {
                var factory = new Factory("Factory A", "Location A");
                var machine = new Machine("CMS", "Machine A");

                factory.AddMachine(machine);

                Assert.Contains(machine, factory.Machines);
                Assert.Equal(factory, machine.Factory);
            }

            [Fact]
            public void RemoveMachine_RemovesMachineFromFactory()
            {
                var factory = new Factory("Factory A", "Location A");
                var machine = new Machine("CMS", "Machine A");

                factory.AddMachine(machine);
                factory.RemoveMachine(machine);

                Assert.DoesNotContain(machine, factory.Machines);
                Assert.Null(machine.Factory);
            }

            [Fact]
            public void AddFactory_AssignsFactoryToMachine()
            {
                var factory = new Factory("Factory A", "Location A");
                var machine = new Machine("CMS", "Machine A");

                machine.AddFactory(factory);

                Assert.Equal(factory, machine.Factory);
                Assert.Contains(machine, factory.Machines);
            }

            [Fact]
            public void RemoveFactory_RemovesFactoryFromMachine()
            {
                var factory = new Factory("Factory A", "Location A");
                var machine = new Machine("CMS", "Machine A");

                machine.AddFactory(factory);
                machine.RemoveFactory();

                Assert.Null(machine.Factory);
                Assert.DoesNotContain(machine, factory.Machines);
            }

            [Fact]
            public void AddMachine_SortsMachinesByName()
            {
                var factory = new Factory("Factory A", "Location A");
                var machineA = new Machine("CMS", "Machine A");
                var machineB = new Machine("CMS", "Machine B");

                factory.AddMachine(machineB);
                factory.AddMachine(machineA);

                var machinesList = new List<Machine>(factory.Machines);
                machinesList.Sort((x, y) => x.Name.CompareTo(y.Name));

                Assert.Equal("Machine A", machinesList[0].Name);
                Assert.Equal("Machine B", machinesList[1].Name);
            }
        }
    }
}
