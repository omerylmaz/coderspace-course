namespace InterfaceSegregation.BadCode;

internal class SamsungPrinter : IPrinter
{
    public void Fax(string content)
    {
        Console.WriteLine($"Fax: {content}");
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
        Console.WriteLine($"SendEmail: {emailAddress} {content}");
    }

    public void SendSms(string content)
    {
        Console.WriteLine($"Send Sms: {content}");
    }

    public void SendSms(string content, string format)
    {
        Console.WriteLine($"SendSms with {format}: {content}");
    }
}
