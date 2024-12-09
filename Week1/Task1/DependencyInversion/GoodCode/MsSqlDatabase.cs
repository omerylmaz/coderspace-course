namespace DependencyInversion.GoodCode;

internal class MsSqlDatabase : IDatabase
{
    public void Connect()
    {
        Console.WriteLine("MsSql: connected");
    }

    public void Add(string data)
    {
        Console.WriteLine($"MsSql: data added: {data}");
    }
}
