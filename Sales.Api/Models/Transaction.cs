namespace Sales.Api.Models;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public string Product { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Seller { get; set; } = string.Empty;
}

public enum TransactionType
{
    SaleClient = 1,
    SalePartner = 2,
    CommisionPaid = 3,
    CommisionReceived = 4,
}