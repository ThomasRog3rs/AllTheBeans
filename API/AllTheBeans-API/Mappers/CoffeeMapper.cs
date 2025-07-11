using AllTheBeans_API.Models;
using AllTheBeans_API.Services;
namespace AllTheBeans_API.Mappers;

public static class CoffeeMapper
{
    public static async Task<CoffeeResponseDTO> ToResponseDTO(Coffee coffee, BeanOfTheDayService beanOfTheDayService)
    {
        return new CoffeeResponseDTO
        {
            Id = coffee.Id,
            Name = coffee.Name ?? string.Empty,
            Description = coffee.Description ?? string.Empty,
            Country = coffee.Country ?? string.Empty,
            Image = coffee.Image ?? string.Empty,
            Cost = coffee.Cost,
            Colour = coffee.Colour ?? string.Empty,
            IsBeanOfTheDay = await beanOfTheDayService.IsBeanOfTheDay(coffee.Id)
        };
    }
    
    public static void PatchFromDto(this Coffee coffee, CoffeeUpdateDTO dto)
    {
        if (dto.Name != null) coffee.Name = dto.Name;
        if (dto.Description != null) coffee.Description = dto.Description;
        if (dto.Country != null) coffee.Country = dto.Country;
        if (dto.Image != null) coffee.Image = dto.Image;
        if (dto.Cost.HasValue) coffee.Cost = dto.Cost.Value;
        if (dto.Colour != null) coffee.Colour = dto.Colour;
    }
}