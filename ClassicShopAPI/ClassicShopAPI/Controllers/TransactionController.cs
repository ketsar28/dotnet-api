using ClassicShopAPI.Entities;
using ClassicShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassicShopAPI.Controllers;

[ApiController]
[Route("/api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public TransactionController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] Purchase payload)
    {
        var transaction = await _purchaseService.CreateTransaction(payload);
        return Created("/api/transactions", transaction);
    }
}