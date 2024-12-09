// See https://aka.ms/new-console-template for more information
using DependencyInversion.GoodCode;
using DependencyInversion.Models;
using BadCode = DependencyInversion.BadCode;

Console.WriteLine("Hello, World!");

#region BadCode
var productService = new BadCode.ProductService();
Product product = new()
{
    Id = 1,
    Name = "Hp Notebook",
    Category = "Computer"
};
productService.AddProduct(product);
#endregion

#region GoodCode

Product product2 = new()
{
    Id = 2,
    Name = "Asus Notebook",
    Category = "Computer"
};

IDatabase db = new MsSqlDatabase();
var productService2 = new ProductService(db);
productService2.AddData(product2);
#endregion
