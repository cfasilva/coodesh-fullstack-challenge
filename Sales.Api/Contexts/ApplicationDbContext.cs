using Microsoft.EntityFrameworkCore;
using Sales.Api.Models;

namespace Sales.Api.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<SellerModel> Sellers { get; set; }
    public DbSet<TransactionModel> Transactions { get; set; }    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) { }

}