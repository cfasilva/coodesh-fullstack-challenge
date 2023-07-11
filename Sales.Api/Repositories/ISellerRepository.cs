using Sales.Api.Models;

namespace Sales.Api.Repositories;

public interface ISellerRepository
{
    Task<IEnumerable<Seller>> GetSellersAsync();
    Task<Seller> GetSellerAsync(int id);
    Task CreateSellerAsync(Seller seller);
    Task UpdateSellerAsync(Seller seller);
    Task DeleteSellerAsync(int id);
}