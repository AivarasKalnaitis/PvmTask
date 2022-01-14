using NSubstitute;
using PVM_task;
using PVM_task.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace PvmTaskTests
{
    public class VatCalculatorTests
    {
        private readonly IVatCalculator _vatCalculator = Substitute.For<IVatCalculator>();
        private readonly IInvoicePrinter _invoicePrinter = Substitute.For<IInvoicePrinter>();

        [Fact]
        public void CalculateVat_ReturnsZero_WhenProviderIsNotTaxPayer()
        {
            var providerCountry = new Country(1, true, "Lithuania", 21);
            var serviceProvider = new ServiceProvider(1, "Kaimo draugai", providerCountry, true);


            var customerCountry = new Country(1, true, "Poland", 23);
            var customer = new Customer(1, "Tomas Krapikas", customerCountry, true, PersonType.LEGAL_PERSON);

            _vatCalculator.CalculateVAT(serviceProvider, Arg.Any<Customer>()).Returns(0);
            Assert.Equal(0, _vatCalculator.CalculateVAT(serviceProvider, customer));

            _vatCalculator.Received().CalculateVAT(serviceProvider, Arg.Any<Customer>());
        }

        [Fact]
        public void CalculateVat_ReturnsCustomerCountryVat_WhenProviderCountryIsTheSame()
        {
            var providerCountry = new Country(1, true, "Lithuania", 21);
            var serviceProvider = new ServiceProvider(1, "Kaimo draugai", providerCountry, true);

            var customer = new Customer(1, "Tomas Krapikas", providerCountry, true, PersonType.LEGAL_PERSON);

            _vatCalculator.CalculateVAT(serviceProvider, Arg.Any<Customer>()).Returns(providerCountry.Vat);
            Assert.Equal(providerCountry.Vat, _vatCalculator.CalculateVAT(serviceProvider, customer));

            _vatCalculator.Received().CalculateVAT(serviceProvider, Arg.Any<Customer>());
        }

        [Fact]
        public void CalculateVat_ReturnsCustomerCountryVat_WhenClientLivesOutsideEU()
        {
            var providerCountry = new Country(1, true, "Lithuania", 21);
            var serviceProvider = new ServiceProvider(1, "Kaimo draugai", providerCountry, true);

            var customerCountry = new Country(1, false, "Russia", 20);
            var customer = new Customer(1, "Tomas Krapikas", customerCountry, true, PersonType.LEGAL_PERSON);

            _vatCalculator.CalculateVAT(Arg.Any<ServiceProvider>(), Arg.Any<Customer>()).Returns(0);
            Assert.Equal(0, _vatCalculator.CalculateVAT(serviceProvider, customer));

            _vatCalculator.Received().CalculateVAT(Arg.Any<ServiceProvider>(), customer);
        }

        [Fact]
        public void CalculateVat_ReturnsCustomerCountryVat_WhenClientLivesInsideEU_AndIsNotTaxPayer()
        {
            var providerCountry = new Country(1, true, "Lithuania", 21);
            var serviceProvider = new ServiceProvider(1, "Kaimo draugai", providerCountry, true);

            var customerCountry = new Country(1, true, "Poland", 23);
            var customer = new Customer(1, "Tomas Krapikas", customerCountry, false, PersonType.LEGAL_PERSON);

            _vatCalculator.CalculateVAT(Arg.Any<ServiceProvider>(), Arg.Any<Customer>()).Returns(customer.Country.Vat);
            Assert.Equal(customer.Country.Vat, _vatCalculator.CalculateVAT(serviceProvider, customer));

            _vatCalculator.Received().CalculateVAT(Arg.Any<ServiceProvider>(), customer);
        }

        [Fact]
        public void CalculateVat_ReturnsCustomerCountryVat_WhenClientLivesInsideEU_AndIsTaxPayer()
        {
            var providerCountry = new Country(1, true, "Lithuania", 21);
            var serviceProvider = new ServiceProvider(1, "Kaimo draugai", providerCountry, true);

            var customerCountry = new Country(1, true, "Poland", 23);
            var customer = new Customer(1, "Tomas Krapikas", customerCountry, true, PersonType.LEGAL_PERSON);

            _vatCalculator.CalculateVAT(Arg.Any<ServiceProvider>(), Arg.Any<Customer>()).Returns(0);
            Assert.Equal(0, _vatCalculator.CalculateVAT(serviceProvider, customer));

            _vatCalculator.Received().CalculateVAT(Arg.Any<ServiceProvider>(), customer);
        }
    }
}github

