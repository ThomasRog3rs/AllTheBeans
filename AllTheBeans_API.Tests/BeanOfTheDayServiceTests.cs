using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using AllTheBeans_API.Services;
using Microsoft.EntityFrameworkCore;


public class BeanOfTheDayServiceTests
{
    private CoffeeDbContext GetDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<CoffeeDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
        return new CoffeeDbContext(options);
    }

    [Fact]
    public async Task Returns_Todays_Bean_If_Exists()
    {
        //Arrange
        var dbName = Guid.NewGuid().ToString();
        var context = GetDbContext(dbName);

        var coffee = new Coffee
        {
            Id = 1,
            Name = "Coffee 1",
            Country = "Brazil",
            Cost = 9.99m
        };
        context.Coffees.Add(coffee);
        context.BeanOfTheDayHistory.Add(new BeanOfTheDayHistory
        {
            Date = DateTime.Now.Date,
            BeanId = coffee.Id
        });
        context.SaveChanges();

        var service = new BeanOfTheDayService(context);

        //act
        var result = await service.GetBeanOfTheDay();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(coffee.Id, result.Id);
    }

    [Fact]
    public async Task Picks_New_Bean_If_None_For_Today()
    {
        //Arrang
        var dbName = Guid.NewGuid().ToString();
        var context = GetDbContext(dbName);

        var coffee1 = new Coffee
        {
            Id = 1,
            Name = "Coffee 1",
            Country = "Brazil",
            Cost = 9.99m
        };

        var coffee2 = new Coffee
        {
            Id = 2,
            Name = "Coffee 2",
            Country = "Colombia",
            Cost = 10.99m
        };
        context.Coffees.AddRange(coffee1, coffee2);

        //yesterdays bean
        context.BeanOfTheDayHistory.Add(new BeanOfTheDayHistory
        {
            Date = DateTime.Now.Date.AddDays(-1),
            BeanId = coffee1.Id
        });
        context.SaveChanges();

        var service = new BeanOfTheDayService(context);

        //Act
        var result = await service.GetBeanOfTheDay();

        //Assert
        Assert.NotNull(result);
        Assert.NotEqual(coffee1.Id, result.Id); //Should not be yesterday bean
        Assert.Equal(coffee2.Id, result.Id);
    }

    [Fact]
    public async Task Picks_Any_Bean_If_No_History()
    {
        //Arrange
        var dbName = Guid.NewGuid().ToString();
        var context = GetDbContext(dbName);

        var coffee1 = new Coffee
        {
            Id = 1,
            Name = "Coffee 1",
            Country = "Brazil",
            Cost = 9.99m
        };

        var coffee2 = new Coffee
        {
            Id = 2,
            Name = "Coffee 2",
            Country = "Colombia",
            Cost = 10.99m
        };
        context.Coffees.AddRange(coffee1, coffee2);
        context.SaveChanges();

        var service = new BeanOfTheDayService(context);

        //Act
        var result = await service.GetBeanOfTheDay();

        //Assert
        Assert.NotNull(result);
        Assert.Contains(result.Id, new[] { coffee1.Id, coffee2.Id });
    }
}