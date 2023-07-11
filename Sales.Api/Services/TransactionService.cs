using Sales.Api.Models;
using Sales.Api.Repositories;

namespace Sales.Api.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(
        ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
    {
        return await _transactionRepository.GetTransactionsAsync();
    }

    public async Task<Transaction> GetTransactionAsync(int id)
    {
        return await _transactionRepository.GetTransactionAsync(id);
    }

    public async Task CreateTransactionAsync(Transaction transaction)
    {
        await _transactionRepository.CreateTransactionAsync(transaction);
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        await _transactionRepository.UpdateTransactionAsync(transaction);
    }

    public async Task DeleteTransactionAsync(int id)
    {
        await _transactionRepository.DeleteTransactionAsync(id);
    }
}