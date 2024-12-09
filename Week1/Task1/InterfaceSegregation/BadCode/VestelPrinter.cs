namespace InterfaceSegregation.BadCode;

internal class VestelPrinter : IPrinter
{
    public void Fax(string content)
    {
        throw new NotImplementedException();
    }

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

    public void SendEmail(string emailAddress, string content)
    {
        throw new NotImplementedException();
    }

    public void SendSms(string content)
    {
        throw new NotImplementedException();
    }

    public void SendSms(string content, string format)
    {
        throw new NotImplementedException();
    }
}
