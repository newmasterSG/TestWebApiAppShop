using Microsoft.EntityFrameworkCore;
using TestWebApiAppShop.Application.Client.DTOs;
using TestWebApiAppShop.Application.Client.Interfaces;
using TestWebApiAppShop.Infrastructure.Db;

namespace TestWebApiAppShop.Application.Client.Services
{
    public class ClientServices(ShopDbContext dbContext) : IClientServices
    {
        public async Task<List<ClientBirthDateDto>> GetClientByBirthDate(DateTime dateTime, CancellationToken cancellationToken = default)
        {
            var clients = await dbContext.Clients.AsNoTracking().Where(x => x.BirthDate == dateTime.Date).Select(client => new ClientBirthDateDto()
            {
                FullName = string.Join(" ", client.FirstName, client.MiddleName, client.LastName),
                Id = client.Id,
            }).ToListAsync(cancellationToken);

            return clients;
        }

        public async Task<List<ClientLastPurchaseDTO>> GetClientByLastPurchaseByCountDate(int nDate, CancellationToken cancellationToken = default)
        {
            var clients = await dbContext.Clients
                .AsNoTracking()
                .Include(x => x.Purchases)
                .Where(client =>
                        client.Purchases.Any(
                                    purchase => purchase.Date >= DateTime.UtcNow.AddDays(-nDate)))
                .Select(x => new ClientLastPurchaseDTO()
                {
                    Id = x.Id,
                    FullName = string.Join(" ", x.FirstName, x.MiddleName, x.LastName),
                    LastDatePurchase = x.Purchases
                        .OrderByDescending(p => p.Date)
                        .First().Date,
                })
                .ToListAsync(cancellationToken);

            return clients;
        }
    }
}
