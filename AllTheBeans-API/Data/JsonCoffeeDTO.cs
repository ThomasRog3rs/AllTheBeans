using System.Text.Json.Serialization;
namespace AllTheBeans_API.Data;

public class JsonCoffeeDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Cost { get; set; } = string.Empty;
    
    //For some reason in the json this is lowercase, but everything else is uppercase?
    [JsonPropertyName("colour")]
    public string Colour { get; set; } = string.Empty;
}