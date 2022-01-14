using PVM_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM_task
{
    public interface IInvoicePrinter
    {
        void PrintInvoice(ServiceProvider serviceProvider, Customer customer, List<Service> services, decimal price, decimal vat);
    }
}
