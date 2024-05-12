using System.ComponentModel.DataAnnotations;
using Products.Common.Types;

namespace Products.Common.Dtos;

public record CreateProductDto(
    [Required]
     string Name,

    [Required]
     Color Color,

    [Required]
    string Brand
);
