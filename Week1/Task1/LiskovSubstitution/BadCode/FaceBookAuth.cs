using LiskovSubstitution.Models;

namespace LiskovSubstitution.BadCode;

internal class FaceBookAuth : IAuth
{
    public User GetProfileDetails(int id)
    {
        throw new NotImplementedException();
    }

    public void Login(string username, string password)
    {
        Console.WriteLine($"Facebook: Welcome {username}");
    }

    public void Logout(string username)
    {
        Console.WriteLine($"Facebook: {username} logged out");
    }
}
