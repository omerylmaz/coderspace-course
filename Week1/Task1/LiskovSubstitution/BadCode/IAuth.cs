using LiskovSubstitution.Models;

namespace LiskovSubstitution.BadCode;

internal interface IAuth
{
    void Login(string username, string password);
    void Logout(string username);
    User GetProfileDetails(int id);
}
