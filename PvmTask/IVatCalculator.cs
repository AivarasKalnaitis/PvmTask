using PVM_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM_task
{
    public interface IVatCalculator
    {
        decimal CalculateVAT(ServiceProvider serviceProvider, Customer customer);
    }
}
