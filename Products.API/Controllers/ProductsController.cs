using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Products.Business.Service;
using Products.Common.Dtos;

namespace Products.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> Get()
    {
        return Ok(_productService.GetProducts());
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDto> Get(int id)
    {
        return Ok(_productService.GetProduct(id));

    }

    [HttpPost]
    public ActionResult<ProductDto> Post(CreateProductDto product)
    {
        return Ok(_productService.AddProduct(product));
    }

    [HttpPatch("{id}")]
    public ActionResult<ProductDto> Patch(int id, JsonPatchDocument<UpdateProductDto> product)
    {
        return Ok(_productService.PatchProduct(id, product));
    }

    [HttpPut("{id}")]
    public ActionResult<ProductDto> Put(int id, UpdateProductDto product)
    {
        return Ok(_productService.UpdateProduct(id, product));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _productService.DeleteProduct(id);
        return Ok();
    }
}
