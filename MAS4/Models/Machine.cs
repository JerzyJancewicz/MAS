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
        private List<SparePart> _spareParts = new List<SparePart>();
        public Machine(string type, string name)
        {
            _type = type;
            _name = name;
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

        public void AddProductionRecord(ProductionRecord productionRecords)
        {
            if (productionRecords == null) { throw new ArgumentNullException(); }
            _productionRecords.Add(productionRecords);
            productionRecords.AddMachineReference(this);
        }

        public void RemoveProductionRecord(ProductionRecord productionRecord)
        {
            if (productionRecord == null) { throw new ArgumentNullException(); }
            if (_productionRecords.Contains(productionRecord))
            {
                _productionRecords.Remove(productionRecord);
                productionRecord.RemoveMachineReference();
            }
        }

        public void AddSparePart(SparePart sparePart)
        {
            if (sparePart == null) { throw new ArgumentNullException(); }
            if (_spareParts != null)
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
            _spareParts.Remove(sparePart);
            sparePart.RemoveMachine(this);
        }
    }
}
