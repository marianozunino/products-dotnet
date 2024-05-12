using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Products.Business.Domain;
using Products.Business.Repository;
using Products.Common.Dtos;
using Products.Common.Exceptions;

namespace Products.Business.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    // Inject ProductRepository and AutoMapper
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public IEnumerable<ProductDto> GetProducts()
    {
        var products = _productRepository.GetProducts();
        return _mapper.Map<List<ProductDto>>(products);
    }


    public ProductDto GetProduct(int id)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) throw new RecordNotFoundException("Product not found");
        return _mapper.Map<ProductDto>(product);
    }

    public ProductDto AddProduct(CreateProductDto product)
    {
        var createdProduct = _productRepository.AddProduct(new Product
        {
            Name = product.Name,
            Color = product.Color,
            Brand = product.Brand
        });

        return _mapper.Map<ProductDto>(createdProduct);
    }


    public void DeleteProduct(int id)
    {
        if (!_productRepository.ProductExists(id)) throw new RecordNotFoundException("Product not found");
        _productRepository.DeleteProduct(id);
    }



    public ProductDto UpdateProduct(int id, UpdateProductDto productDto)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) throw new RecordNotFoundException("Product not found");

        product.Name = productDto.Name;
        product.Color = productDto.Color;
        product.Brand = productDto.Brand;

        _productRepository.UpdateProduct(product);

        return this.GetProduct(id);
    }

    public ProductDto PatchProduct(int id,
            JsonPatchDocument<UpdateProductDto> productDto)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) throw new RecordNotFoundException("Product not found");

        // Apply the patch
        var update = _mapper.Map<UpdateProductDto>(product);
        productDto.ApplyTo(update);

        // Update the product
        _mapper.Map(update, product);

        _productRepository.UpdateProduct(product);

        return this.GetProduct(id);
    }
}
