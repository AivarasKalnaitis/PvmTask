namespace PVM_task.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public bool IsTaxPayer { get; set; }
        public PersonType PersonType { get; set; }

        public Customer(int id, string name, Country country,bool isTaxPayer, PersonType personType)
        {
            Id = id;
            Name = name;
            Country = country;
            PersonType = personType;

            if (isTaxPayer)
                IsTaxPayer = true;
            else
                IsTaxPayer = false;
        }
    }
}
