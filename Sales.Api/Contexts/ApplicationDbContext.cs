using Microsoft.EntityFrameworkCore;
using Sales.Api.Models;

namespace Sales.Api.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) { }

}