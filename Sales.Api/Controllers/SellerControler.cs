using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Api.Contexts;
using Sales.Api.Models;

namespace Sales.Api.Controllers;

[ApiController]
[Route("api/sellers")]
public class SellerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SellerController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var sellers = await _context.Sellers.ToListAsync();

        return Ok(sellers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var seller = await _context.Sellers.FindAsync(id);

        if (seller == null)
            return NotFound();

        return Ok(seller);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Seller seller)
    {
        await _context.Sellers.AddAsync(seller);
        await _context.SaveChangesAsync();

        return Created($"/api/sellers/{seller.Id}", seller);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, Seller seller)
    {
        if (id != seller.Id)
            return BadRequest();

        _context.Entry(seller).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var seller = await _context.Sellers.FindAsync(id);

        if (seller == null)
            return NotFound();

        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}