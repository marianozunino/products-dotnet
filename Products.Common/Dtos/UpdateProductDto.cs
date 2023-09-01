using System.ComponentModel.DataAnnotations;
using Products.Common.Types;

namespace Products.Common.Dtos;

public class UpdateProductDto
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    [Required]
    public Color Color { get; set; }
    [Required]
    public string Brand { get; set; }
}