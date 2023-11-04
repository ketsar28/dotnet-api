using ClassicShopAPI.Entities;

namespace ClassicShopAPI.Services;

public interface IProductService
{
    Task<Product> CreateProduct(Product payload);
    Task<Product> GetProductById(string id);
    Task<List<Product>> GetProductAll();
    Task<Product> UpdateProduct(Product payload);
    Task DeleteProductById(string id);
}