using Microsoft.AspNetCore.Mvc;
using TestWebApiAppShop.Application.Purchase.Interfaces;

namespace TestWebApiAppShop.WebApi.Contollers
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController(IPurchaseService purchaseService) : ControllerBase
    {
        [HttpGet("requested-categories")]
        public async Task<IActionResult> GetRequestedCategories([FromQuery] int clientId, CancellationToken cancellationToken = default)
        {
            var categories = await purchaseService.GetPurchasedCategoriesByClientIdAsync(clientId, cancellationToken);
            return Ok(categories);
        }
    }
}
