using Microsoft.AspNetCore.Mvc;
using TestWebApiAppShop.Application.Client.Interfaces;

namespace TestWebApiAppShop.WebApi.Contollers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController(IClientServices clientService) : ControllerBase
    {
        [HttpGet("birthdays")]
        public async Task<IActionResult> GetClientsWithBirthdayToday([FromQuery] DateTime date,CancellationToken cancellationToken = default)
        {
            var clients = await clientService.GetClientByBirthDate(date.Date, cancellationToken);
            return Ok(clients);
        }

        [HttpGet("last-purchases")]
        public async Task<IActionResult> GetClientsByLastPurchase([FromQuery] int nDays, CancellationToken cancellationToken = default)
        {
            if (nDays <= 0)
            {
                return BadRequest();
            }

            var clients = await clientService.GetClientByLastPurchaseByCountDate(nDays, cancellationToken);
            return Ok(clients);
        }
    }
}
