namespace DependencyInversion.GoodCode;

internal class MongoDatabase : IDatabase
{
    public void Connect()
    {
        Console.WriteLine("MongoDB: connected");
    }

    public void Add(string data)
    {
        Console.WriteLine($"MongoDB: data added: {data}");
    }
}
