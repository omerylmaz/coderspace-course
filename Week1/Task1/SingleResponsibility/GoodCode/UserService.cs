using SingleResponsibility.Models;

namespace SingleResponsibility.GoodCode;

internal class UserServiceGood
{
    public void RegisterUser(User user)
    {
        // Yalnızca kullanıcının kayıt olması
        Console.WriteLine($"User {user.Username} registered with email");
    }
}
