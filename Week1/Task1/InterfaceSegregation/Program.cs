// See https://aka.ms/new-console-template for more information
using BadCode = InterfaceSegregation.BadCode;
using GoodCode = InterfaceSegregation.GoodCode;

#region Bad Code
// Tüm interface'leri kendi sorumluluğuna göre ayırıp her printer için kendi sorumluluğunda olan interface'leri uyguladım
BadCode.VestelPrinter printer = new();
printer.Fax("hello world");
#endregion

#region Good Code

GoodCode.SamsungPrinter samsungPrinter = new();
samsungPrinter.Fax("hello world");

samsungPrinter.SendSms("fax sended");

#endregion