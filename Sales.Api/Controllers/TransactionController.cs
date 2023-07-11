using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Api.Contexts;
using Sales.Api.Models;

namespace Sales.Api.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TransactionController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var transactions = await _context.Transactions.ToListAsync();
        decimal total = transactions.Sum(t => t.Value);

        return Ok(new
        {
            Total = total,
            Transactions = transactions
        });
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFileAsync(IFormFile file)
    {
        if (file.Length == 0)
            return BadRequest();

        using var reader = new StreamReader(file.OpenReadStream());

        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            TransactionType type;
            switch (line.Substring(0, 1))
            {
                case "1":
                    type = TransactionType.SaleClient;
                    break;
                case "2":
                    type = TransactionType.SalePartner;
                    break;
                case "3":
                    type = TransactionType.CommisionPaid;
                    break;
                case "4":
                    type = TransactionType.CommisionReceived;
                    break;
                default:
                    throw new Exception("Invalid transaction type");
            }

            string date = line.Substring(1, 25);
            DateTime.TryParseExact(date, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate);

            string product = line.Substring(26, 30).Trim();

            string value = line.Substring(56, 10);
            bool v = decimal.TryParse(value, out var parsedValue);

            string seller = line.Substring(66).Trim();

            var transaction = new Transaction
            {
                Type = type,
                Date = parsedDate,
                Product = product,
                Value = parsedValue / 100,
                Seller = seller,
            };

            await _context.Transactions.AddAsync(transaction);
        }

        await _context.SaveChangesAsync();

        return Created("api/transactions", null);
    }
}