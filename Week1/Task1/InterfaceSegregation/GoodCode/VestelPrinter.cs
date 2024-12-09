namespace InterfaceSegregation.GoodCode;

internal class VestelPrinter : IPhotoCopy, IPrint, IScan
{
    public void PhotoCopy(string content)
    {
        Console.WriteLine($"PhotoCopy: {content}");
    }

    public void Print(string content)
    {
        Console.WriteLine($"Print: {content}");
    }

    public void PrintWithFormat(string content, string format)
    {
        Console.WriteLine($"Print with {format}: {content}");
    }

    public void Scan(string content)
    {
        Console.WriteLine($"Scan: {content}");
    }
}
