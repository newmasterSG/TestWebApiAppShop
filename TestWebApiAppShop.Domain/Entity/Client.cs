namespace TestWebApiAppShop.Domain.Entity
{
    public class Client
    {
        public Client()
        {
            Purchases = new List<Purchase>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
