using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services.Implements;

public class ProductService : IProductService
{

    private readonly IRepository<Product> _repository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public Product CreateProduct(Product product)
    {
        try
        {
            var saveProduct = _repository.Save(product);
            _persistence.SaveChanges();
            return saveProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product GetProductById(string id)
    {
        try
        {
            var product = _repository.GetById(Guid.Parse(id));
            if (product is null) throw new Exception("product is not found");
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}