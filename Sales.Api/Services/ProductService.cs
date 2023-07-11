using Sales.Api.Models;
using Sales.Api.Repositories;

namespace Sales.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task<Product> GetProductAsync(int id)
    {
        return await _productRepository.GetProductAsync(id);
    }

    public async Task CreateProductAsync(Product product)
    {
        await _productRepository.CreateProductAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateProductAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteProductAsync(id);
    }
}