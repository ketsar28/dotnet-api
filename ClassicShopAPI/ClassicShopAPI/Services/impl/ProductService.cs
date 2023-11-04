using ClassicShopAPI.Entities;
using ClassicShopAPI.Exceptions;
using ClassicShopAPI.Repositories;

namespace ClassicShopAPI.Services.impl;

/*
 * setelah membuat service interface dan service implnya itu harus di daftarkan ke DI (Dependency Injection). didaftarkan di file class Program.cs
 */
public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public async Task<Product> CreateProduct(Product payload)
    {
        var product = await _repository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetProductById(string id)
    {
        try
        {
            var product = await _repository.FindByIdAsync(Guid.Parse(id));
            if (product is null) throw new NotFoundException("product is not found");
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Product>> GetProductAll()
    {
        return await _repository.FindAllAsync();
    }

    public async Task<Product> UpdateProduct(Product payload)
    {
        var product = _repository.Update(payload);
        await _persistence.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProductById(string id)
    {
        var product = await GetProductById(id);
        _repository.Delete(product);
        await _persistence.SaveChangesAsync();

    }
}