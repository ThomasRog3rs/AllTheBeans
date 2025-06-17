using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using AllTheBeans_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllTheBeans_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : Controller
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly CoffeeDbContext _context;
    private readonly BeanOfTheDayService _beanOfTheDayService;

    public CoffeeController(ILogger<CoffeeController> logger, CoffeeDbContext context, BeanOfTheDayService beanOfTheDayService)
    {
        _logger = logger;
        _context = context;
        _beanOfTheDayService = beanOfTheDayService;
    }
    
    [HttpGet("get-all-coffee")]
    public async Task<List<Coffee>> GetAllCoffee()
    {
        //I am using ToListAsync to prevent thread blockin
        return await _context.Coffees.ToListAsync();
    }

    [HttpGet("bean-of-the-day")]
    public async Task<Coffee> GetBeanOfTheDay()
    {
        return await _beanOfTheDayService.GetBeanOfTheDay();
    }
}