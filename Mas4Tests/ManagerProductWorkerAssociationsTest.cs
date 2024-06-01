using MAS4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas4Tests
{
    public class ManagerProductWorkerAssociationsTest
    {
        [Fact]
        public void AddProduct_AssignsProductToManager()
        {
            var manager = new Manager("Manager A");
            var product = new Product("123", "Product A", 100);

            manager.CreateProductReference(new HashSet<Product>());
            manager.AddProduct(product);

            Assert.Contains(product, manager.Products);
            Assert.Equal(manager, product.Manager);
        }

        [Fact]
        public void RemoveProduct_RemovesProductFromManager()
        {
            var manager = new Manager("Manager A");
            var product = new Product("123", "Product A", 100);

            manager.CreateProductReference(new HashSet<Product>());
            manager.AddProduct(product);
            manager.RemoveProduct(product);

            Assert.DoesNotContain(product, manager.Products);
            Assert.Null(product.Manager);
        }

        [Fact]
        public void CreateProductReference_AssignsProductsToManager()
        {
            var manager = new Manager("Manager A");
            var products = new HashSet<Product>
            {
                new Product("123", "Product A", 100),
                new Product("456", "Product B", 200)
            };

            manager.CreateProductReference(products);

            Assert.Equal(2, manager.Products.Count);
            foreach (var product in products)
            {
                Assert.Contains(product, manager.Products);
                Assert.Equal(manager, product.Manager);
            }
        }

        [Fact]
        public void CreateProductReference_ThrowsIfManagerAlreadyHasWorkers()
        {
            var manager = new Manager("Manager A");
            var workers = new HashSet<Worker>
            {
                new Worker("Worker A", "Surname A"),
                new Worker("Worker B", "Surname B")
            };

            manager.CreateWorkerReference(workers);

            var products = new HashSet<Product>
            {
                new Product("123", "Product A", 100),
                new Product("456", "Product B", 200)
            };

            Assert.Throws<InvalidOperationException>(() => manager.CreateProductReference(products));
        }

        [Fact]
        public void RemoveProductReference_RemovesAllProductReferences()
        {
            var manager = new Manager("Manager A");
            var products = new HashSet<Product>
            {
                new Product("123", "Product A", 100),
                new Product("456", "Product B", 200)
            };

            manager.CreateProductReference(products);
            manager.RemoveProductReference();

            Assert.Null(manager.Products);
            foreach (var product in products)
            {
                Assert.Null(product.Manager);
            }
        }
        [Fact]
        public void AddWorker_AssignsWorkerToManager()
        {
            var manager = new Manager("Manager A");
            var worker = new Worker("Worker A", "Surname A");

            manager.CreateWorkerReference(new HashSet<Worker>());
            manager.AddWorker(worker);

            Assert.Contains(worker, manager.Workers);
            Assert.Equal(manager, worker.Manager);
        }

        [Fact]
        public void RemoveWorker_RemovesWorkerFromManager()
        {
            var manager = new Manager("Manager A");
            var worker = new Worker("Worker A", "Surname A");

            manager.CreateWorkerReference(new HashSet<Worker>());
            manager.AddWorker(worker);
            manager.RemoveWorker(worker);

            Assert.DoesNotContain(worker, manager.Workers);
            Assert.Null(worker.Manager);
        }

        [Fact]
        public void CreateWorkerReference_AssignsWorkersToManager()
        {
            var manager = new Manager("Manager A");
            var workers = new HashSet<Worker>
            {
                new Worker("Worker A", "Surname A"),
                new Worker("Worker B", "Surname B")
            };

            manager.CreateWorkerReference(workers);

            Assert.Equal(2, manager.Workers.Count);
            foreach (var worker in workers)
            {
                Assert.Contains(worker, manager.Workers);
                Assert.Equal(manager, worker.Manager);
            }
        }

        [Fact]
        public void CreateWorkerReference_ThrowsIfManagerAlreadyHasProducts()
        {
            var manager = new Manager("Manager A");
            var products = new HashSet<Product>
            {
                new Product("123", "Product A", 100),
                new Product("456", "Product B", 200)
            };

            manager.CreateProductReference(products);

            var workers = new HashSet<Worker>
            {
                new Worker("Worker A", "Surname A"),
                new Worker("Worker B", "Surname B")
            };

            Assert.Throws<InvalidOperationException>(() => manager.CreateWorkerReference(workers));
        }

        [Fact]
        public void RemoveWorkerReference_RemovesAllWorkerReferences()
        {
            var manager = new Manager("Manager A");
            var workers = new HashSet<Worker>
            {
                new Worker("Worker A", "Surname A"),
                new Worker("Worker B", "Surname B")
            };

            manager.CreateWorkerReference(workers);
            manager.RemoveWorkerReference();

            Assert.Null(manager.Workers);
            foreach (var worker in workers)
            {
                Assert.Null(worker.Manager);
            }
        }
    }
}
