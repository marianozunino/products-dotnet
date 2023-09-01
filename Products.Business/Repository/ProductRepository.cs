using Products.Business.Domain;
using Products.Business.Persistence;

namespace Products.Business.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _ctx;

    public ProductRepository(DataContext ctx)
    {
        _ctx = ctx;
    }

    public IEnumerable<Product?> GetProducts()
    {
        return _ctx.Products.ToList();
    }

    public Product? GetProduct(int id)
    {
        return _ctx.Products.FirstOrDefault(p => p.Id == id);
    }

    public Product AddProduct(Product product)
    {
        _ctx.Products.Add(product);
        _ctx.SaveChanges();
        return product;
    }

    public void UpdateProduct(Product product)
    {
        _ctx.Products.Update(product);
        _ctx.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _ctx.Products.FirstOrDefault(p => p.Id == id);
        if (product is null) return;
        _ctx.Products.Remove(product);
        _ctx.SaveChanges();
    }

    public bool ProductExists(int id)
    {
        return _ctx.Products.Any(p => p.Id == id);
    }
}