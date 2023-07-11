using Sales.Api.Models;

namespace Sales.Api.Services;

public interface ITransactionService
{
    Task<IEnumerable<Transaction>> GetTransactionsAsync();
    Task<Transaction> GetTransactionAsync(int id);
    Task CreateTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(int id);
}