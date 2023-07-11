using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Api.Services;

namespace Sales.Api.Controllers;

[ApiController]
[Route("api/sellers")]
public class SellerController : ControllerBase
{
    private readonly SellerService _sellerService;

    public SellerController(
        SellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seller>>> GetSellersAsync()
    {
        return Ok(await _sellerService.GetSellersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seller>> GetSellerAsync(int id)
    {
        var seller = await _sellerService.GetSellerAsync(id);
        if (seller == null)
        {
            return NotFound();
        }

        return Ok(seller);
    }

    [HttpPost]
    public async Task<ActionResult<Seller>> CreateSellerAsync(Seller seller)
    {
        await _sellerService.CreateSellerAsync(seller);
        return Created("", seller);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSellerAsync(int id, Seller seller)
    {
        if (id != seller.Id)
        {
            return BadRequest();
        }

        await _sellerService.UpdateSellerAsync(seller);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSellerAsync(int id)
    {
        await _sellerService.DeleteSellerAsync(id);
        return NoContent();
    }
}