using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS4.Models
{
    public class Machine
    {
        private string _type;
        private string _name;

        private List<ProductionRecord> _productionRecords = new List<ProductionRecord>();   
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
            TeacherValidator.ValidateParticipation(participation);
            _participations.Remove(participation);
            participation.Teacher = null;
        }
    }
}
