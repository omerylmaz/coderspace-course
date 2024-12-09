using DependencyInversion.Models;

namespace DependencyInversion.BadCode;

internal class ProductService
{
    private readonly MongoDatabase _mongoDatabase;
    public ProductService()
    {
        // Doğrudan alt seviye sınıfa bağımlılık oluyor,
        // ileride değişilmek istendiği zaman database değiştirilmesi maliyetli olacak
        _mongoDatabase = new MongoDatabase();  
    }

    public void AddProduct(Product product)
    {
        _mongoDatabase.Connect();
        _mongoDatabase.Add($"{product.Id}, {product.Name}, {product.Category}");
    }
}
