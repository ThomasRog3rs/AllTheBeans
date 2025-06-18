using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AllTheBeans_API.Models
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Country { get; set; }
        public string? Image { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public string? Colour { get; set; }
    }

    public class JsonCoffeeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Cost { get; set; } = string.Empty;

        // For some reason in the json this is lowercase, but everything else is uppercase?
        [JsonPropertyName("colour")]
        public string Colour { get; set; } = string.Empty;
    }
    
    public class CoffeeResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public string Colour { get; set; } = string.Empty;
        
        public bool IsBeanOfTheDay { get; set; }
    }
    
    public class CoffeeCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Colour { get; set; }
    }
    
    public class CoffeeUpdateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public decimal? Cost { get; set; }
        public string? Colour { get; set; }
    }
}