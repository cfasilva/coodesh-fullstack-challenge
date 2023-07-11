using Sales.Api.Models;
using Sales.Api.Repositories;

namespace Sales.Api.Services;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(
        ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<IEnumerable<Seller>> GetSellersAsync()
    {
        return await _sellerRepository.GetSellersAsync();
    }

    public async Task<Seller> GetSellerAsync(int id)
    {
        return await _sellerRepository.GetSellerAsync(id);
    }

    public async Task CreateSellerAsync(Seller seller)
    {
        await _sellerRepository.CreateSellerAsync(seller);
    }

    public async Task UpdateSellerAsync(Seller seller)
    {
        await _sellerRepository.UpdateSellerAsync(seller);
    }

    public async Task DeleteSellerAsync(int id)
    {
        await _sellerRepository.DeleteSellerAsync(id);
    }
}