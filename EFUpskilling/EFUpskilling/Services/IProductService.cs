using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface IProductService
{
    Product CreateProduct(Product product);
    Product GetProductById(string id);
}