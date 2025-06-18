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
    public DbSet<BeanOfTheDayHistory> BeanOfTheDayHistory { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Lookups on the Date filed will be common, so adding an index for it will make the query more efficent
        modelBuilder.Entity<BeanOfTheDayHistory>()
            .HasIndex(botd => botd.Date)
            .IsUnique();
    }
}