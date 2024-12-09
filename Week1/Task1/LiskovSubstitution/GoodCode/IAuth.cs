namespace LiskovSubstitution.GoodCode;

internal interface IAuth
{
    void Login(string username, string password);
    void Logout(string username);
}
