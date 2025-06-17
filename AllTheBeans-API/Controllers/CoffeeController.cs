using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllTheBeans_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : Controller
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly CoffeeDbContext _context;

    public CoffeeController(ILogger<CoffeeController> logger, CoffeeDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet(Name = "GetAllCoffee")]
    public async Task<IEnumerable<Coffee>> GetAllCoffee()
    {
        //I am using ToListAsync to prevent thread blockin
        return await _context.Coffees.ToListAsync();
    }
}