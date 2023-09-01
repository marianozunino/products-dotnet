using Products.Business.Domain;

namespace Products.Business.Repository;

public interface IProductRepository
{
    IEnumerable<Product?> GetProducts();
    Product? GetProduct(int id);
    Product AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
    bool ProductExists(int id);
}