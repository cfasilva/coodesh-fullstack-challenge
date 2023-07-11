using Sales.Api.Models;

namespace Sales.Api.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}