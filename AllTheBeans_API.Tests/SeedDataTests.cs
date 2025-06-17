using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AllTheBeans_API.Tests;

public class SeedDataTests
{
    [Fact]
    public async Task Test1()
    {
        //I decided to use a guid for the database name so that it stays unique between each test run
        var options = new DbContextOptionsBuilder<CoffeeDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        var serviceProvider = new ServiceCollection()
            .AddSingleton(options)
            .AddDbContext<CoffeeDbContext>()
            .BuildServiceProvider();

        // await SeedData.Initialize(serviceProvider);
    }
}
