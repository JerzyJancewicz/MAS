﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Product
    {
        private string _serialNumber;
        private string _name;
        private double _price;

        private static HashSet<string> _serialNumbers = new HashSet<string>();
        private List<ProductionRecord> _productionRecords = new List<ProductionRecord>();
        private Manager? _manager;

        private bool _isProductionRecordRemoved = false;
        private bool _isProductionRecordAdded = false;

        private static readonly int MAX_NAME_LENGTH = 50;
        private static readonly double MAX_PRICE_CHANGE = 1.2;

        public Product(string serialNumber, string name, double price)
        {
            if (serialNumber == null || name == null) { throw new ArgumentNullException(); }
            _serialNumber = serialNumber;
            _name = name;
            _price = price;

            _serialNumbers.Add(serialNumber);
        }

        public void AddProductionRecord(ProductionRecord productionRecords)
        {
            if (productionRecords == null) { throw new ArgumentNullException(); }
            if (!_isProductionRecordAdded) 
            {
                _isProductionRecordAdded = true;
                _productionRecords.Add(productionRecords);
                productionRecords.AddProductReference(this);
            }
            _isProductionRecordAdded = false;
        }

        public void RemoveProductionRecord(ProductionRecord productionRecord)
        {
            if (productionRecord == null) { throw new ArgumentNullException(); }
            if (!_isProductionRecordRemoved)
            {
                _isProductionRecordRemoved = true;
                _productionRecords.Remove(productionRecord);
                productionRecord.Machine?.RemoveProductionRecord(productionRecord);
                productionRecord.RemoveMachineReference();
                productionRecord.RemoveProductReference();
                _isProductionRecordRemoved = false;
            }
        }
        public void AddManager(Manager manager) 
        {
            if (manager == null) { throw new ArgumentNullException(); }
            _manager = manager;
            manager.AddProduct(this);
        }
        public void RemoveManager()
        {
            if (_manager != null) 
            {
                _manager.RemoveProduct(this);
            }
            _manager = null;
        }
        public Manager Manager 
        {
            get => _manager!;
            private set => _manager = value;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name can not be null");
                }
                if (value.Length > MAX_NAME_LENGTH)
                {
                    throw new ArgumentException("Name length is over 50 characters");
                }
                _name = value;
            }
        }

        public double Price
        {
            get => _price;
            set 
            {
                if (value > _price * MAX_PRICE_CHANGE)
                {
                    throw new ArgumentException("Price can not be over " + MAX_PRICE_CHANGE + " times previous value");
                }
                _price = value;
            }
        }

        public string SerialNumber
        {
            get => _serialNumber;
            set 
            {
                if (_serialNumbers.Contains(value))
                {
                    throw new ArgumentException("Value already exists");
                }
                _serialNumbers.Remove(_serialNumber);
                _serialNumber = value;
                _serialNumbers.Add(_serialNumber);
            }
        }
        public static ReadOnlyCollection<string> SerialNumbers
        {
            get => new ReadOnlyCollection<string>(_serialNumbers.ToList());
        }

        public List<ProductionRecord> ProductionRecords 
        {
            get => _productionRecords;
        }
    }
}
