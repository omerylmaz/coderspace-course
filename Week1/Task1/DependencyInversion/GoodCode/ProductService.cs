using DependencyInversion.BadCode;
using DependencyInversion.Models;

namespace DependencyInversion.GoodCode;

internal class ProductService
{
    // Alt seviye sınıflara doğrudan bağımlılık ortadan kaldırıp interface ile dolaylı çağırdım
    private readonly IDatabase _database;

    public ProductService(IDatabase database)
    {
        // Dependency injection ile bağımlılık büyük ölçüde azalttım
        _database = database;
    }

    public void AddData(Product product)
    {
        _database.Connect();
        _database.Add($"{product.Id}, {product.Name}, {product.Category}");
    }
}
