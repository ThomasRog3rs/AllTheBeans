using AllTheBeans_API.Data;
using AllTheBeans_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AllTheBeans_API.Services;

public class BeanOfTheDayService
{
    private readonly CoffeeDbContext _dbContext;
    private readonly Random _random = new Random();

    public BeanOfTheDayService(CoffeeDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Coffee> GetBeanOfTheDay()
    {
        var today = DateTime.Now.Date;

        var todaysBean = await _dbContext.BeanOfTheDayHistory
            .Where(bean => bean.Date == today)
            .FirstOrDefaultAsync();

        if (todaysBean != null)
        {
            return await _dbContext.Coffees
                .FirstOrDefaultAsync(coffee => coffee.Id == todaysBean.BeanId);
        }
        
        var yesterday = DateTime.Now.Date.AddDays(-1);
        var yesterdaysBean = await _dbContext.BeanOfTheDayHistory
            .Where(bean => bean.Date == yesterday)
            .FirstOrDefaultAsync();
        
        int? yesterdaysBeanId = yesterdaysBean?.BeanId;
        
        var eligableBeans = await _dbContext.Coffees
            .Where(bean => bean.Id != yesterdaysBeanId)
            .ToListAsync();
        
        var newBeanOfTheDay = eligableBeans[_random.Next(0, eligableBeans.Count)];
        
        _dbContext.BeanOfTheDayHistory.Add(new BeanOfTheDayHistory
        {
            Date = today,
            BeanId = newBeanOfTheDay.Id,
        });
        await _dbContext.SaveChangesAsync();
        
        return newBeanOfTheDay;
    }
    public async Task<bool> IsBeanOfTheDay(int beanId)
    {
        var today = DateTime.Now.Date;

        var todaysBean = await _dbContext.BeanOfTheDayHistory
            .Where(bean => bean.Date == today)
            .FirstOrDefaultAsync();
        
        return todaysBean?.BeanId == beanId;
    }
}