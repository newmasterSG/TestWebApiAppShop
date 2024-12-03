using Microsoft.EntityFrameworkCore;
using TestWebApiAppShop.Application.Purchase.DTOs;
using TestWebApiAppShop.Application.Purchase.Interfaces;
using TestWebApiAppShop.Infrastructure.Db;

namespace TestWebApiAppShop.Application.Purchase.Services
{
    public class PurchaseService(ShopDbContext dbContext) : IPurchaseService
    {
        public async Task<List<CategoryPurchaseDTO>> GetPurchasedCategoriesByClientIdAsync(int clientId, CancellationToken cancellationToken = default)
        {
            var categories = await dbContext.Purchases
                .AsNoTracking()
                .Where(p => p.CustomerId == clientId)
                .SelectMany(p => p.PurchaseItems)
                .GroupBy(pi => pi.Product.Category)
                .Select(g => new CategoryPurchaseDTO
                {
                    CategoryId = g.Key.Id,
                    CategoryName = g.Key.Name,
                    TotalUnitsPurchased = g.Sum(p => p.Quantity)
                })
                .ToListAsync(cancellationToken);

            return categories;
        }
    }
}
