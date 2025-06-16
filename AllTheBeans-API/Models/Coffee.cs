using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllTheBeans_API.Models;

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

    public bool IsBeanOfTheDay { get; set; }
}