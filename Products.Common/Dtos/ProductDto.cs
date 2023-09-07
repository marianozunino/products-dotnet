using Products.Common.Types;

namespace Products.Common.Dtos;

public class ProductDto
{
    public ProductDto(string name, Color color, string brand, int id)
    {
        Name = name;
        Color = color;
        Brand = brand;
        Id = id;
    }
    
    public ProductDto()
    {
    }
    

    public string Name { get; set; }
    public Color Color { get; set; }
    public string Brand { get; set; }
    public int Id { get; set; }
}