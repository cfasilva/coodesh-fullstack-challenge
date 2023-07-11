using Microsoft.EntityFrameworkCore;
using Sales.Api.Contexts;
using Sales.Api.Models;

namespace Sales.Api.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly ApplicationDbContext _context;

    public SellerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seller>> GetSellersAsync()
    {
        return await _context.Sellers.ToListAsync();
    }

    public async Task<Seller> GetSellerAsync(int id)
    {
        return await _context.Sellers.FindAsync(id);
    }

    public async Task CreateSellerAsync(Seller seller)
    {
        await _context.Sellers.AddAsync(seller);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSellerAsync(Seller seller)
    {
        _context.Sellers.Update(seller);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSellerAsync(int id)
    {
        var seller = await _context.Sellers.FindAsync(id);
        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync();
    }
}