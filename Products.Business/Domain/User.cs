using System.ComponentModel.DataAnnotations;
using Products.Common.Types;

namespace Products.Business.Domain;

public class User
{
    [Required] public required string Name { get; set; }
    [Required] public Color Color { get; set; }
    [Required] public required string Brand { get; set; }
    [Required] public int Id { get; set; }
}
