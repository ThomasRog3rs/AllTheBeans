using AllTheBeans_API.Data;
using AllTheBeans_API.Mappers;
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
    private readonly CoffeeDbContext _dbContext;
    private readonly BeanOfTheDayService _beanOfTheDayService;
    
    private bool CoffeeExists(int id)
    {
        return _dbContext.Coffees.Any(e => e.Id == id);
    }

    public CoffeeController(ILogger<CoffeeController> logger, CoffeeDbContext context, BeanOfTheDayService beanOfTheDayService)
    {
        _logger = logger;
        _dbContext = context;
        _beanOfTheDayService = beanOfTheDayService;
    }
    
    [HttpGet("get-all-coffee")]
    public async Task<ActionResult<List<CoffeeResponseDTO>>> GetAllCoffee()
    {
        var coffees = await _dbContext.Coffees.ToListAsync();
        var responseDtos = await Task.WhenAll(
            coffees.Select(async coffee => await CoffeeMapper.ToResponseDTO(coffee, _beanOfTheDayService))
        );
        return Ok(responseDtos.ToList());
    }

    [HttpGet("bean-of-the-day")]
    public async Task<ActionResult<CoffeeResponseDTO>> GetBeanOfTheDay()
    {
        var coffee = await _beanOfTheDayService.GetBeanOfTheDay();
        if (coffee == null)
            return NotFound();

        var responseDto = await CoffeeMapper.ToResponseDTO(coffee, _beanOfTheDayService);
        return Ok(responseDto);
    }
}