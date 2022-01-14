using System;
using System.Collections.Generic;

namespace PVM_task.Models
{
    public class Order
    {
        public int Number { get; set; }
        public DateTime Date_Ordered { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public List<Service> Services { get; set; }

        private readonly IVatCalculator _vatCalculator;
        private readonly IInvoicePrinter _invoicePrinter;

        public Order(IVatCalculator vatCalculator, IInvoicePrinter invoicePrinter, int number, DateTime date_ordered, Customer customer, ServiceProvider serviceProvider, decimal price, List<Service> services)
        {
            _vatCalculator = vatCalculator;
            _invoicePrinter = invoicePrinter;

            Number = number;
            Date_Ordered = date_ordered;
            Status = OrderStatus.RECEIVED;
            Customer = customer;
            ServiceProvider = serviceProvider;
            Price = price;
            Vat = _vatCalculator.CalculateVAT(serviceProvider, customer);
            Services = services;
        }

        public void PrintInvoice()
        {
            _invoicePrinter.PrintInvoice(ServiceProvider, Customer, Services, Price, Vat);
        }
    }
}
