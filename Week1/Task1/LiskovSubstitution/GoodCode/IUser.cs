using LiskovSubstitution.Models;

namespace LiskovSubstitution.GoodCode;

internal interface IUser
{
    User GetProfileDetails(int id);

}
