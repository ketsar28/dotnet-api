using ClassicShopAPI.Entities;
using ClassicShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassicShopAPI.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(payload);
        }
        var product = await  _productService.CreateProduct(payload);
        return Created("/api/product", product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        // throw new Exception(); // dipaksa gagal - middleware
        var products = await _productService.GetProductAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _productService.GetProductById(id);
        return Ok(product);
    }
}