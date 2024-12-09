
using LiskovSubstitution.Models;

namespace LiskovSubstitution.BadCode;

internal class GoogleAuth : IAuth
{
    public User GetProfileDetails(int id)
    {
        return new User { Id = id, Email = "omer@gmail.com", Name = "omer" };
    }

    public void Login(string username, string password)
    {
        Console.WriteLine($"Google: Welcome {username}");
    }

    public void Logout(string username)
    {
        Console.WriteLine($"Google: {username} logged out");
    }
}
