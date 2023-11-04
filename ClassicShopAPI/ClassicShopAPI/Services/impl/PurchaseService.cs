using ClassicShopAPI.DTO;
using ClassicShopAPI.Entities;
using ClassicShopAPI.Repositories;

namespace ClassicShopAPI.Services.impl;

public class PurchaseService : IPurchaseService
{

    private readonly IRepository<Purchase> _repository;
    private readonly IPersistence _persistence;
    private readonly IProductService _productService;

    public PurchaseService(IRepository<Purchase> repository, IPersistence persistence, IProductService productService)
    {
        _repository = repository;
        _persistence = persistence;
        _productService = productService;
    }

    public async Task<PurchaseResponse> CreateTransaction(Purchase payload)
    {
        payload.TransDate = DateTime.Now;
        await _persistence.BeginTransactionAsync();
        try
        {
            // ada kemungkinan terkena stackoverflow
            var purchase = await _repository.SaveAsync(payload);
            await _persistence.SaveChangesAsync();
            
            foreach (var purchaseDetail in purchase.PurchaseDetails)
            {
                var product = await _productService.GetProductById(purchaseDetail.ProductId.ToString());
                product.Stock -= purchaseDetail.Qty;
            }

            var detailResponses = purchase.PurchaseDetails.Select(purchaseDetail => new PurchaseDetailResponse()
                {
                    ProductId = purchaseDetail.ProductId.ToString(),
                    Qty = purchaseDetail.Qty
                })
                .ToList();

            PurchaseResponse purchaseResponse = new()
            {
                UserId = purchase.UserId.ToString(),
                TransDate = DateTime.Now,
                PurchaseDetail = detailResponses
            };

            await _persistence.SaveChangesAsync();
            await _persistence.CommitTransactionAsync();
            return purchaseResponse;
        }
        catch (Exception e)
        {
            await _persistence.RollbackTransactionAsync();
            Console.WriteLine(e);
            throw;
        }
    }
}