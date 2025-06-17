using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AllTheBeans_API.Tests;

public class SeedDataTests
{
    [Fact]
    public async Task SeedData_Initialize_WithValidJson_SeedsCoffeesCorrectly()
    {
        //I decided to use a guid for the database name so that it stays unique between each test run
        var options = new DbContextOptionsBuilder<CoffeeDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        var serviceProvider = new ServiceCollection()
            .AddSingleton(options)
            .BuildServiceProvider();
        
        // var testJson = await File.ReadAllTextAsync("Data.coffees.json");
        var testProjectDir = Directory.GetCurrentDirectory();
        var jsonFilePath = Path.Combine(testProjectDir, "Data", "coffees.json");
        var testJson = await File.ReadAllTextAsync(jsonFilePath);
        
        //Act
        await SeedData.Initialize(serviceProvider, testJson);
        
        //Aserts
        await using var ctx = new CoffeeDbContext(options);
        var coffees = await ctx.Coffees.ToListAsync();

        Assert.NotEmpty(coffees);
        Assert.All(coffees, coffee => Assert.NotNull(coffee.Name));
        Assert.All(coffees, coffee => Assert.NotNull(coffee.Image));
        Assert.All(coffees, coffee => Assert.IsType<decimal>(coffee.Cost));
    }
}
