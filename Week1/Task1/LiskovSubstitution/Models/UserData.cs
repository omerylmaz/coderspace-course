namespace LiskovSubstitution.Models;

internal class UserData
{
    public static List<User> GetUsers()
    {
        List<User> users = new List<User>()
        {
            new User { Name = "omer", Email = "omer@gmail.com", Id = 1, Password = "123" },
            new User { Name = "emre", Email = "emre@gmail.com", Id = 2, Password = "123" },
            new User { Name = "metin", Email = "metin@gmail.com", Id = 3, Password = "123" },
            new User { Name = "efe", Email = "efe@gmail.com", Id = 4, Password = "123" }
        };
        return users;
    }
}
