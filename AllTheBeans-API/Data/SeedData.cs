using System.Globalization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using AllTheBeans_API.Models;
namespace AllTheBeans_API.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, string json)
    {
        using (var context = new CoffeeDbContext(serviceProvider.GetRequiredService<DbContextOptions<CoffeeDbContext>>()))
        {
            await context.Database.EnsureCreatedAsync();

            if (await context.Coffees.AnyAsync())
            {
                return;
            }
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<JsonCoffeeDTO>? coffeDTOs = JsonSerializer.Deserialize<List<JsonCoffeeDTO>>(json, options);

            if (coffeDTOs == null)
            {
                return;
            }

            var coffees = coffeDTOs.Select(dto => new Coffee
            {
                Name = dto.Name,
                Description = dto.Description,
                Country = dto.Country,
                Image = dto.Image,
                Colour = dto.Colour,
                IsBeanOfTheDay = dto.IsBeanOfTheDay,
                Cost = decimal.Parse(
                    dto.Cost.Replace("£", ""),
                    NumberStyles.Currency,
                    CultureInfo.GetCultureInfo("en-GB")
                )
            });

            await context.Coffees.AddRangeAsync(coffees);
            await context.SaveChangesAsync();
        }
    }
}