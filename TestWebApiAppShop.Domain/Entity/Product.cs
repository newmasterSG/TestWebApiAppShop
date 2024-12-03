namespace TestWebApiAppShop.Domain.Entity
{
    public class Product
    {
        public Product()
        {
            PurchaseItems = new List<PurchaseItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        public string Article {  get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
