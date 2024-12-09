namespace InterfaceSegregation.BadCode;

internal interface IPrinter
{
    void Print(string content);
    void PrintWithFormat(string content, string format);
    void Scan(string content);
    void Fax(string content);
    void PhotoCopy(string content);
    void SendEmail(string emailAddress, string content);
    void SendSms(string content);
    void SendSms(string content, string format);
}
