using Microsoft.AspNetCore.JsonPatch;
using Products.Common.Dtos;

namespace Products.Business.Service;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts();
    ProductDto GetProduct(int id);
    ProductDto AddProduct(CreateProductDto product);
    ProductDto PatchProduct(int id, JsonPatchDocument<UpdateProductDto> productDto);
    ProductDto UpdateProduct(int id, UpdateProductDto productDto);
    void DeleteProduct(int id);
}
