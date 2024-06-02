using MAS4.Models;
using System;
using Xunit;

namespace MAS4Tests
{
    public class AssociationTests
    {
        [Fact]
        public void AddProductionRecordToProduct_ShouldAddRecord()
        {
            // Arrange
            var product = new Product("SN123", "Product1", 100.0);
            var product2 = new Product("SN122", "Product2", 100.0);
            var machine = new Machine("CMS", "Machine1");
            var productionRecord = new ProductionRecord(DateTime.UtcNow.AddDays(1), product, machine);

            // Act
            product2.AddProductionRecord(productionRecord);

            // Assert
            Assert.Contains(productionRecord, product2.ProductionRecords);
            Assert.Equal(product2, productionRecord.Product);
        }

        [Fact]
        public void RemoveProductionRecordFromProduct_ShouldRemoveRecord()
        {
            // Arrange
            var product = new Product("SN123", "Product1", 100.0);
            var machine = new Machine("CMS", "Machine1");
            var productionRecord = new ProductionRecord(DateTime.UtcNow.AddDays(1), product, machine);
            product.AddProductionRecord(productionRecord);

            // Act
            product.RemoveProductionRecord(productionRecord);

            // Assert
            Assert.DoesNotContain(productionRecord, product.ProductionRecords);
            Assert.Null(productionRecord.Product);
            Assert.DoesNotContain(productionRecord, machine.ProductionRecords);
            Assert.Null(productionRecord.Machine);

        }

        [Fact]
        public void AddProductionRecordToMachine_ShouldAddRecord()
        {
            // Arrange
            var product = new Product("SN123", "Product1", 100.0);
            var machine = new Machine("CMS", "Machine1");
            var productionRecord = new ProductionRecord(DateTime.UtcNow.AddDays(1), product, machine);

            // Act
            machine.AddProductionRecord(productionRecord);

            // Assert
            Assert.Contains(productionRecord, machine.ProductionRecords);
            Assert.Equal(machine, productionRecord.Machine);
        }

        [Fact]
        public void RemoveProductionRecordFromMachine_ShouldRemoveRecord()
        {
            // Arrange
            var product = new Product("SN123", "Product1", 100.0);
            var machine = new Machine("CMS", "Machine1");
            var productionRecord = new ProductionRecord(DateTime.UtcNow.AddDays(1), product, machine);
            machine.AddProductionRecord(productionRecord);

            // Act
            machine.RemoveProductionRecord(productionRecord);

            // Assert
            Assert.DoesNotContain(productionRecord, machine.ProductionRecords);
            Assert.Null(productionRecord.Machine);
            Assert.DoesNotContain(productionRecord, product.ProductionRecords);
            Assert.Null(productionRecord.Product);
        }
    }
}
