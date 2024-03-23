using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products.Backoffice.Models;
using Products.Business.Domain;
using Products.Business.Persistence;
using Products.Common.Exceptions;

namespace Products.Backoffice.Controllers;

public class ProductController : Controller
{
    private readonly DataContext _ctx;
    private readonly ILogger<ProductController> _logger;

    public ProductController(DataContext dbContext, ILogger<ProductController> logger)
    {
        _ctx = dbContext;
        _logger = logger;
    }

    // GET
    public IActionResult Index()
    {
        var products = _ctx.Products.ToList();
        return View(products);
    }

    // GET /product/1
    public IActionResult Details(int id)
    {
        var product = _ctx.Products.Find(id);
        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }
        _ctx.Products.Add(product);
        _ctx.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var product = _ctx.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _ctx.Products.Update(product);
        _ctx.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        try

        {
            var p = _ctx.Products.Find(id);

            if (p == null)
            {
                return NotFound();
            }

            _ctx.Products.Remove(p);
            _ctx.SaveChanges();
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
