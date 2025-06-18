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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CoffeeResponseDTO>> GetCoffee(int id)
    {
        var coffee = await _dbContext.Coffees.FindAsync(id);

        if (coffee == null)
            return NotFound();
    
        return await CoffeeMapper.ToResponseDTO(coffee, _beanOfTheDayService);
    }
    
    [HttpPost]
    public async Task<ActionResult<CoffeeResponseDTO>> CreateCoffee(CoffeeUpdateDTO coffeeToCreate)
    {
        //I don't want Id to be available here
        var coffee = new Coffee
        {
            Name = coffeeToCreate.Name,
            Description = coffeeToCreate.Description,
            Country = coffeeToCreate.Country,
            Image = coffeeToCreate.Image,
            Cost = coffeeToCreate.Cost,
            Colour = coffeeToCreate.Colour
        };
    
        _dbContext.Coffees.Add(coffee);
        await _dbContext.SaveChangesAsync();
    
        return await CoffeeMapper.ToResponseDTO(coffee, _beanOfTheDayService);
    }
}