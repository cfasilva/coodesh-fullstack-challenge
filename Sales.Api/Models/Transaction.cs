namespace Sales.Api.Models;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public decimal Value { get; set; }
    public int SellerId { get; set; }
    public Seller Seller { get; set; }
}

public enum TransactionType
{
    SaleClient = 1,
    SalePartner = 2,
    CommisionPaid = 3,
    CommisionReceived = 4,
}