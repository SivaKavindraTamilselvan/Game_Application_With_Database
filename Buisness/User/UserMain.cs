using WordGame.Inputs;

namespace WordGame.Service;

public class UserService
{
    InputsCheck inputsCheck = new InputsCheck();
    
    public void AddUser()
    {
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
    }
}