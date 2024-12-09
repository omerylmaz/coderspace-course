namespace LiskovSubstitution.GoodCode;

internal class FaceBookAuth : IAuth
{
    public void Login(string username, string password)
    {
        Console.WriteLine($"Facebook: Welcome {username}");
    }

    public void Logout(string username)
    {
        Console.WriteLine($"Facebook: {username} logged out");
    }
}
