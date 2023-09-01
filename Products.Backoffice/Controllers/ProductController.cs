using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products.Backoffice.Models;
using Products.Business.Service;
using Products.Common.Dtos;
using Products.Common.Exceptions;

namespace Products.Backoffice.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    // GET
    public IActionResult Index()
    {
        var products = _productService.GetProducts();
        return View(products);
    }
    
    // GET /product/1
    public IActionResult Details(int id)
    {
        var product = _productService.GetProduct(id);
        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return View(productDto);
        }
        _productService.AddProduct(productDto);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var product = _productService.GetProduct(id);
        return View(product);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return View(productDto);
        }
        _productService.UpdateProduct(id, new UpdateProductDto()
        {
            Name = productDto.Name,
            Brand = productDto.Brand,
            Color = productDto.Color
                
        });
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _productService.DeleteProduct(id);
        }
        catch (Exception e)
        {
            return e is RecordNotFoundException ? NotFound() : StatusCode(500);
        }
        return RedirectToAction(nameof(Index));
    }
    
    [Route("Error/{statusCode:int}")] 
    public IActionResult Error(int statusCode) 
    {     
        var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();      
    
        return View(new ErrorViewModel { StatusCode = statusCode, OriginalPath = feature?.OriginalPath }); 
    } 
}