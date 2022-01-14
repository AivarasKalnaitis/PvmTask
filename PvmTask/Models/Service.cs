using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM_task.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Service(string name)
        {
            Name = name;
        }
    }
}
