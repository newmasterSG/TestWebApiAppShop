namespace TestWebApiAppShop.Application.Client.DTOs
{
    public class ClientLastPurchaseDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime? LastDatePurchase { get; set; }
    }
}
