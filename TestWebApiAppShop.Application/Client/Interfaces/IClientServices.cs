using TestWebApiAppShop.Application.Client.DTOs;

namespace TestWebApiAppShop.Application.Client.Interfaces
{
    public interface IClientServices
    {
        Task<List<ClientBirthDateDto>> GetClientByBirthDate(DateTime dateTime, CancellationToken cancellationToken = default);
        Task<List<ClientLastPurchaseDTO>> GetClientByLastPurchaseByCountDate(int nDate, CancellationToken cancellationToken = default);
    }
}