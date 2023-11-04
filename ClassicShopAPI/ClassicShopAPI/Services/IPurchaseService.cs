using ClassicShopAPI.DTO;
using ClassicShopAPI.Entities;

namespace ClassicShopAPI.Services;

public interface IPurchaseService
{
    Task<PurchaseResponse> CreateTransaction(Purchase purchase);
}