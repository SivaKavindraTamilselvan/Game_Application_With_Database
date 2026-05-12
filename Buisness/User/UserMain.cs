using WordGame.Inputs;
using WordGame.DataAccess;
using WordGame.Models;

namespace WordGame.Service;

public class UserService
{
    InputsCheck inputsCheck = new InputsCheck();
    
    public void AddUser()
    {
        /*
        Console.WriteLine("Enter the Used Details To Add User");
        Console.WriteLine();
        Console.WriteLine("Enter Your Name");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Your Email");
        string email = inputsCheck.EmailInputs();
        Console.WriteLine("Enter Your Password");
        string password = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Your Role");
        string role = Console.ReadLine() ?? string.Empty;
        */

        Users users = new Users();
        users.Name = "siva kavindra";
        users.Email = "sivakavi@gmail.com";
        users.Password = "siva";

        UserRepository userRepository = new UserRepository();
        Users createduser = userRepository.Create(users);
        Console.WriteLine(createduser);
    }
    public Users? LoginUser()
    {
        UserRepository userRepository = new UserRepository();
        var user = userRepository.LoginUser("sivakavin@gmail.com","siva");
        if(user == null)
        {
            return null;
        }
        Console.WriteLine(user);
        return user;
    }
}