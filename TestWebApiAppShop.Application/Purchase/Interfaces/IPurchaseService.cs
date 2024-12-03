using TestWebApiAppShop.Application.Purchase.DTOs;

namespace TestWebApiAppShop.Application.Purchase.Interfaces
{
    public interface IPurchaseService
    {
        Task<List<CategoryPurchaseDTO>> GetPurchasedCategoriesByClientIdAsync(int clientId, CancellationToken cancellationToken = default);
    }
}