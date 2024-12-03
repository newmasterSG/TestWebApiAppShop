namespace TestWebApiAppShop.Domain.Entity
{
    public class Purchase
    {
        public Purchase() => PurchaseItems = new List<PurchaseItem>();

        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public int CustomerId { get; set; }
        public Client Customer { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
