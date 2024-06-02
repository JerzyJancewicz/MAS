using MAS4.Models;
using System;
using Xunit;

namespace MAS4Tests
{
    public class SparePartMachineAssociationTests
    {
        [Fact]
        public void AddSparePartToMachine_ShouldAddSparePart()
        {
            // Arrange
            var machine = new Machine("CMS", "Machine1");
            var sparePart = new SparePart("SparePart1", 1.5, 50.0, 10);

            // Act
            machine.AddSparePart(sparePart);

            // Assert
            Assert.Contains(sparePart, machine.SpareParts);
            Assert.Contains(machine, sparePart.Machines);
        }

        [Fact]
        public void RemoveSparePartFromMachine_ShouldRemoveSparePart()
        {
            // Arrange
            var machine = new Machine("CMS", "Machine1");
            var sparePart = new SparePart("SparePart1", 1.5, 50.0, 10);
            machine.AddSparePart(sparePart);

            // Act
            machine.RemoveSparePart(sparePart);

            // Assert
            Assert.DoesNotContain(sparePart, machine.SpareParts);
            Assert.DoesNotContain(machine, sparePart.Machines);
        }

        [Fact]
        public void AddMachineToSparePart_ShouldAddMachine()
        {
            // Arrange
            var machine = new Machine("CMS", "Machine1");
            var sparePart = new SparePart("SparePart1", 1.5, 50.0, 10);

            // Act
            sparePart.AddMachine(machine);

            // Assert
            Assert.Contains(machine, sparePart.Machines);
            Assert.Contains(sparePart, machine.SpareParts);
        }

        [Fact]
        public void RemoveMachineFromSparePart_ShouldRemoveMachine()
        {
            // Arrange
            var machine = new Machine("CMS", "Machine1");
            var sparePart = new SparePart("SparePart1", 1.5, 50.0, 10);
            sparePart.AddMachine(machine);

            // Act
            sparePart.RemoveMachine(machine);

            // Assert
            Assert.DoesNotContain(machine, sparePart.Machines);
            Assert.DoesNotContain(sparePart, machine.SpareParts);
        }

        [Fact]
        public void AddSparePartToWrongTypeMachine_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var machine = new Machine("UnsupportedType", "Machine1");
            var sparePart = new SparePart("SparePart1", 1.5, 50.0, 10);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => machine.AddSparePart(sparePart));
        }
    }
}
