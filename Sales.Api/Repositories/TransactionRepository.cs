using Microsoft.EntityFrameworkCore;
using Sales.Api.Contexts;
using Sales.Api.Models;

namespace Sales.Api.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetTransactionAsync(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task CreateTransactionAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactionAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}