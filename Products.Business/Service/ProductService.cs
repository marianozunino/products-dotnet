using Products.Business.Domain;
using Products.Business.Repository;
using Products.Common.Dtos;
using Products.Common.Exceptions;

namespace Products.Business.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    // Inject ProductRepository
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public IEnumerable<ProductDto> GetProducts()
    {
        var products = _productRepository.GetProducts();

        return products.Select(MapProductToProductDto!);
    }


    public ProductDto GetProduct(int id)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) throw new RecordNotFoundException("Product not found");
        return MapProductToProductDto(product);
    }

    public ProductDto AddProduct(CreateProductDto product)
    {
        var createdProduct = _productRepository.AddProduct(new Product
        {
            Name = product.Name,
            Color = product.Color,
            Brand = product.Brand
        });

        return MapProductToProductDto(createdProduct);
    }

    public ProductDto UpdateProduct(int id, UpdateProductDto productDto)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) throw new RecordNotFoundException("Product not found");

        product.Name = productDto.Name;
        product.Color = productDto.Color;
        product.Brand = productDto.Brand;

        _productRepository.UpdateProduct(product);

        return GetProduct(id);
    }

    public void DeleteProduct(int id)
    {
        if (!_productRepository.ProductExists(id)) throw new RecordNotFoundException("Product not found");
        _productRepository.DeleteProduct(id);
    }

    // TODO: This can be avoided using AutoMapper, also this should not be in this class
    private ProductDto MapProductToProductDto(Product product)
    {
        return new ProductDto(
            product.Name,
            product.Color.ToString(),
            product.Brand,
            product.Id
        );
    }
}
