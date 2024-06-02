using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Machine
    {
        private string _type;
        private string _name;

        private readonly List<string> _types = new List<string>() { "CMS", "DPS" };

        private List<ProductionRecord> _productionRecords = new List<ProductionRecord>(); 
        private HashSet<SparePart> _spareParts = new HashSet<SparePart>();
        private Factory? _factory;

        private bool _isProductionRecordRemoved = false;
        private bool _isProductionRecordAdded = false;

        public Machine(string type, string name)
        {
            if (type == null || name == null) { throw new ArgumentNullException("values can not be null"); }
            _type = type;
            _name = name;
        }

        public Factory Factory 
        {
            get => _factory!;
            private set => _factory = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("value can not be null");
        }
        public string Type
        {
            get => _type;
            set => _type = value ?? throw new ArgumentNullException("value can not be null");
        }

        public void AddFactory(Factory factory)
        {
            if (factory == null) throw new ArgumentNullException("value can not be null");
            _factory = factory;
            factory.AddMachine(this);
        }

        public void RemoveFactory()
        {
            if (_factory != null) 
            {
                _factory.RemoveMachine(this);
            }
            _factory = null;
        }

        public void AddProductionRecord(ProductionRecord productionRecords)
        {
            if (productionRecords == null) { throw new ArgumentNullException(); }
            if (!_isProductionRecordAdded) 
            {
                _isProductionRecordAdded = true;
                _productionRecords.Add(productionRecords);
                productionRecords.AddMachineReference(this);
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
                productionRecord.RemoveMachineReference();
                productionRecord.Product?.RemoveProductionRecord(productionRecord);
                productionRecord.RemoveProductReference();
                _isProductionRecordRemoved = false;
            }
        }

        public void AddSparePart(SparePart sparePart)
        {
            if (sparePart == null) { throw new ArgumentNullException(); }
            if (_spareParts != null && !_spareParts.Contains(sparePart))
            {
                if (!_types.Contains(this.Type))
                {
                    throw new InvalidOperationException("this machine type does not have spare parts");
                }
                _spareParts.Add(sparePart);
                sparePart.Machines.Add(this);
            }
        }
        public void RemoveSparePart(SparePart sparePart)
        {
            if (sparePart == null) { throw new ArgumentNullException(); }
            if (_spareParts.Contains(sparePart)) 
            {
                _spareParts.Remove(sparePart);
                sparePart.RemoveMachine(this);
            }
        }

        public List<ProductionRecord> ProductionRecords
        {
            get => _productionRecords;
        }
        public HashSet<SparePart> SpareParts 
        {
            get => _spareParts;
        }
    }
}
