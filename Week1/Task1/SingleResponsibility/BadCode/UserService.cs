using SingleResponsibility.Models;

namespace SingleResponsibility.BadCode;

internal class UserServiceBad
{
    public void RegisterUser(User user)
    {

        // Kullanıcının kayıt olma işlemi
        Console.WriteLine($"User {user.Username} registered.");

        // Aynı zamanda doğrulama yapıyor burada
        Console.WriteLine($"Verification sended via email {user.Email}.");
    }
}
