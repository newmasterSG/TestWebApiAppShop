namespace TestWebApiAppShop.Application.Purchase.DTOs
{
    public class CategoryPurchaseDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int TotalUnitsPurchased { get; set; }
    }
}
