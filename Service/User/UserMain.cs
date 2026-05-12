namespace WordGame.Service;

public class UserService
{
    public void AddUser()
    {
        Console.WriteLine("Enter the Used Details To Add User");
        Console.WriteLine("Enter Your Name");
        string name = Console.ReadLine() ?? string.Empty();
        Console.WriteLine("Enter Your Email");
        string email = Console.ReadLine() ?? string.Empty();
        Console.WriteLine("Enter Your Password");
        string password = Console.ReadLine() ?? string.Empty();
        UserRepository user = new UserRepository();
        Users users = new Users();
        users.Email = email;
        users.Name = name;
        users.Password = password;
        user.Add()
    }
}