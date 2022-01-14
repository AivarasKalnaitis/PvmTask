using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVM_task.Models
{
    public class Country
    {
        public int ID { get; set; }
        public bool IsEU { get; set; }
        public string Name { get; set; }
        public decimal Vat { get; set; }

        public Country(int id, bool isEU, string name, decimal vat)
        {
            ID = id;
            IsEU = isEU;
            Name = name;
            Vat = vat;
        }
    }
}
