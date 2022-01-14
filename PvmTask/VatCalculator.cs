using PVM_task.Models;
using System;

namespace PVM_task
{
    public class VatCalculator : IVatCalculator
    {
        public decimal CalculateVAT(ServiceProvider serviceProvider, Customer customer)
        {
            // Kai paslaugų tiekėjas nėra PVM mokėtojas - PVM mokestis nuo užsakymo sumos nėra skaičiuojamas
            if (serviceProvider.IsTaxPayer == false)
                return 0;

            else
            {
                // 4. Kai užsakovas ir paslaugų tiekėjas gyvena toje pačioje šalyje - visada taikomas PVM
                if (customer.Country == serviceProvider.Country)
                    return customer.Country.Vat;

                // 1. Gyvena už EU ribų - PVM taikomas 0%
                if (customer.Country.IsEU == false)
                    return 0;

                else
                {
                    // 2. Gyvena EU, yra ne PVM mokėtojas, bet gyvena skirtingoje šalyje nei paslaugų tiekėjas. Taikomas PVM x %, kur x -toje šalyje taikomas PVM procentas
                    if (customer.IsTaxPayer == false && customer.Country != serviceProvider.Country)
                        return customer.Country.Vat;


                    // 3. Gyvena EU, yra PVM mokėtojas, bet gyvena skirtingoje šalyje nei paslaugų tiekėjas. Taikomas 0 % pagal atvirkštinį apmokestinimą
                    if (customer.IsTaxPayer && customer.Country != serviceProvider.Country)
                        return 0;
                }
            }

            return 0;
        }
    }
}
