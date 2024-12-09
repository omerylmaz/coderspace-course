using SingleResponsibility.Models;

namespace SingleResponsibility.GoodCode;

internal class VerificationService
{
    // Ayrılmış bir şekilde doğrulama seçenekleri
    public void VerifyWithEmail(string email)
    {
        Console.WriteLine($"Verification sended via email {email}");
    }

    public void VerifyWithSms(string phoneNumber)
    {
        Console.WriteLine($"Verification sended via Phone Number {phoneNumber}");
    }

    public void VerifyWithTwoFactor(User user)
    {
        Console.WriteLine($"Verification sended via Two Factor for this user {user.Username}");
    }
}
