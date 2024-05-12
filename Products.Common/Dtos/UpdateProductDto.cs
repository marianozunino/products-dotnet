using System.ComponentModel.DataAnnotations;
using Products.Common.Types;
namespace Products.Common.Dtos;

public record UpdateProductDto(
    [Required]
    [MinLength(1)]
        string Name,
    [Required]
        Color Color,
    [Required]
        string Brand
);


