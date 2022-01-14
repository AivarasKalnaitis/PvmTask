namespace PVM_task.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public bool IsTaxPayer { get; set; }

        public ServiceProvider(int id, string name, Country country, bool isTaxPayer)
        {
            Id = id;
            Name = name;
            Country = country;

            if (isTaxPayer)
                IsTaxPayer = true;
            else
                IsTaxPayer = false;
        }
    }
}
