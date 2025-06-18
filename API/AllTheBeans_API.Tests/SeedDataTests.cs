using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AllTheBeans_API.Tests;

public class SeedDataTests
{
    private static DbContextOptions<CoffeeDbContext> CreateCtxOptions(string dbName)
    {
        return new DbContextOptionsBuilder<CoffeeDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
    }

    private static ServiceProvider CreateServiceProvider(DbContextOptions<CoffeeDbContext> options)
    {
        return new ServiceCollection()
            .AddSingleton(options)
            .BuildServiceProvider();
    }

    private static async Task<string> GetTestJson()
    {
        // var testJson = await File.ReadAllTextAsync("Data.coffees.json");
        var testProjectDir = Directory.GetCurrentDirectory();
        var jsonFilePath = Path.Combine(testProjectDir, "Data", "coffees.json");
        return await File.ReadAllTextAsync(jsonFilePath);
    }
    
    [Fact]
    public async Task SeedData_Initialize_WithValidJson_SeedsCoffeesCorrectly()
    {
        //I decided to use a guid for the database name so that it stays unique between each test run
        var options = CreateCtxOptions(Guid.NewGuid().ToString());
        var serviceProvider = CreateServiceProvider(options);
        var testJson = await GetTestJson();
        
        //Act
        await SeedData.Initialize(serviceProvider, testJson);
        
        //Aserts
        await using var ctx = new CoffeeDbContext(options);
        var coffees = await ctx.Coffees.ToListAsync();

        Assert.NotEmpty(coffees);
        Assert.True(coffees.Count == 15);
        Assert.All(coffees, coffee => Assert.NotNull(coffee.Name));
        Assert.All(coffees, coffee => Assert.NotNull(coffee.Image));
        Assert.All(coffees, coffee => Assert.IsType<decimal>(coffee.Cost));
    }

    [Fact]
    public async Task Seed_DoesNotWriteToDb_WhenDbAlreadyExists()
    {
        var options = CreateCtxOptions("CoffeeTestDb");
        var serviceProvider = CreateServiceProvider(options);
        var testJson = await GetTestJson();
        
        //Seed1
        await SeedData.Initialize(serviceProvider, testJson);
        
        //Seed2
        await SeedData.Initialize(serviceProvider, testJson);
        
        //Assert
        await using var ctx = new CoffeeDbContext(options);
        var coffees = await ctx.Coffees.ToListAsync();
        Assert.Equal(15, coffees.Count);
    }
}
