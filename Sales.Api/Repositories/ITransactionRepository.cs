using Sales.Api.Models;

namespace Sales.Api.Repositories;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetTransactionsAsync();
    Task<Transaction> GetTransactionAsync(int id);
    Task CreateTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(int id);
}