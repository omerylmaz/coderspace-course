namespace InterfaceSegregation.GoodCode;

internal interface IPrint
{
    void Print(string content);
    void PrintWithFormat(string content, string format);
}

internal interface IScan
{
    void Scan(string content);
}

internal interface IFax
{
    void Fax(string content);
}

internal interface IPhotoCopy
{
    void PhotoCopy(string content);
}

internal interface IEmail
{
    void SendEmail(string emailAddress, string content);
}

internal interface ISms
{
    void SendSms(string content);
    void SendSms(string content, string format);
}