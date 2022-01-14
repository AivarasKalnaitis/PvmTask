using PVM_task.Models;
using System;
using System.Collections.Generic;

namespace PVM_task
{
    public class InvoicePrinter : IInvoicePrinter
    {
        public void PrintInvoice(ServiceProvider serviceProvider, Customer customer, List<Service> services, decimal price, decimal vat)
        {
            Console.WriteLine("INVOICE:");
            Console.WriteLine("Company: {0,-10} {1,-10}", serviceProvider.Name, serviceProvider.Country);
            Console.WriteLine("Customer: {0,-10} {1,-10}", customer.Name, customer.Country);

            foreach (var service in services)
                Console.WriteLine(service.Name);

            Console.WriteLine("Total price: {0,-10}", price + price * vat / 100);
        }
    }
}
