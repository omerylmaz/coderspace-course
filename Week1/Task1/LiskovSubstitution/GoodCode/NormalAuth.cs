
using LiskovSubstitution.Models;

namespace LiskovSubstitution.GoodCode;

internal class NormalAuth : IAuth, IUser
{
    public User GetProfileDetails(int id)
    {
        var user = UserData.GetUsers().Where(a => a.Id == id).FirstOrDefault();
        return user;
    }

    public void Login(string username, string password)
    {
        var user = UserData.GetUsers().Where(a => a.Name.Equals(username) && a.Password.Equals(password));
        if (user != null)
            Console.WriteLine("User logged in succesfully");
        else Console.WriteLine("Username or password is wrong");
    }

    public void Logout(string username)
    {
        Console.WriteLine($"{username} logged out");
    }
}
