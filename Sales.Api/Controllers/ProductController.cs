using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Api.Services;

namespace Sales.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(
        ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductAsync(int id)
    {
        var product = await _productService.GetProductAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProductAsync(Product product)
    {
        await _productService.CreateProductAsync(product);
        return Created("", product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }
        await _productService.UpdateProductAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}