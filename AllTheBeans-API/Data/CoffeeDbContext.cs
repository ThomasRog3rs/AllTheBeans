using Microsoft.EntityFrameworkCore;
using AllTheBeans_API.Models;
namespace AllTheBeans_API.Data;

public class CoffeeDbContext : DbContext
{
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Coffee> Coffees { get; set; }
}