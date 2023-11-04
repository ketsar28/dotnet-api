using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services.Implements;

/*
 * kita tidak boleh menginject class implementasinya/servicenya (business logic), yang diinject itu repositorynya atau interfacenya
 */

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

    public Purchase CreateTransaction(Purchase purchase)
    {
        _persistence.BeginTransaction();
        try
        {
            var savePurchase = _repository.Save(purchase);
            _persistence.SaveChanges();
            
            foreach (var purchaseDetail in savePurchase.PurchaseDetails)
            {
                var product = _productService.GetProductById(purchaseDetail.ProductId.ToString());
                product.Stock -= purchaseDetail.Qty;
            }

            _persistence.SaveChanges();
            _persistence.Commit();

            return savePurchase;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }
}