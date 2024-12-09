namespace DependencyInversion.GoodCode;

internal interface IDatabase
{
    void Connect();
    void Add(string data);
}
