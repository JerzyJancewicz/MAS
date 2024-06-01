using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Manager
    {
        private string _name;

        private HashSet<Product>? _products;
        private HashSet<Worker>? _workers;

        public Manager(string name)
        {
            if (name == null) { throw new ArgumentNullException(); }
            _name = name;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }
        public void CreateProductReference(HashSet<Product> products)
        {
            if (_workers != null) { throw new InvalidOperationException(); }
            if (products == null) { throw new ArgumentNullException(); }

            _products = new HashSet<Product>();
            foreach (var product in products)
            {
                _products.Add(product);
                product.AddManager(this);
            }
        }
        public void CreateWorkerReference(HashSet<Worker> workers)
        {
            if (_products != null) { throw new InvalidOperationException(); }
            if (workers == null) { throw new ArgumentNullException(); }

            _workers = new HashSet<Worker>();
            foreach (var worker in workers)
            {
                _workers.Add(worker);
                worker.AddManager(this);
            }
        }
        public void RemoveProductReference() 
        {
            if (_products != null)
            {
                foreach (var product in _products)
                {
                    if (_products.Contains(product)) 
                    {
                        product.RemoveManager();
                    }
                }
                _products = null;
            }
        }
        public void RemoveWorkerReference()
        {
            if(_workers != null)
            {
                foreach (var worker in _workers)
                {
                    if (_workers.Contains(worker)) 
                    {
                        worker.RemoveManager();
                    }
                }
                _workers = null;
            }
        }

        public void AddProduct(Product product)
        {
            if (product == null) { throw new ArgumentNullException(); }
            if (_workers != null)
            {
                throw new InvalidOperationException();
            }
            if(_products != null && !_products.Contains(product))
            {
                _products.Add(product);
                product.AddManager(this);
            }
        }
        public void AddWorker(Worker worker)
        {
            if (worker == null) { throw new ArgumentNullException(); }
            if (_products != null)
            {
                throw new InvalidOperationException();
            }
            if (_workers != null && !_workers.Contains(worker))
            {
                _workers.Add(worker);
                worker.AddManager(this);
            }
        }
        public void RemoveProduct(Product product)
        {
            if (product == null) { throw new ArgumentNullException(); }
            if (_workers != null)
            {
                throw new InvalidOperationException();
            }
            if (_products != null && _products.Contains(product))
            {
                _products.Remove(product);
                product.RemoveManager();
            }
        }
        public void RemoveWorker(Worker worker)
        {
            if (worker == null) { throw new ArgumentNullException(); }
            if (_products != null)
            {
                throw new InvalidOperationException();
            }
            if (_workers != null && _workers.Contains(worker))
            {
                _workers.Remove(worker);
                worker.RemoveManager();
            }
        }

        public HashSet<Worker> Workers 
        {
            get => _workers!;
        }
        public HashSet<Product> Products 
        {
            get => _products!;
        }
    }
}
