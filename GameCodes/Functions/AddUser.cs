using WordGame.IO;
using WordGame.Service;
using WordGame.Models;

namespace WordGame.Functions;

public class UserFunctions
{
    protected readonly UserService userService;
    InputsCheck inputsCheck = new InputsCheck();
    public UserFunctions(UserService _userService)
    {
        userService = _userService;
    }
    
    public void AddUser()
    {

        Console.WriteLine("Enter the Used Details To Add User");
        Console.WriteLine();

        Console.WriteLine("Enter Your Name");
        string name = inputsCheck.NameInputs();

        Console.WriteLine("Enter Your Email");
        string email = inputsCheck.EmailInputs();

        Console.WriteLine("Enter Your Password");
        string password = inputsCheck.PasswordInputs();

        Console.WriteLine("Enter Your Role");
        Console.WriteLine("Enter 1 For User");
        Console.WriteLine("Enter 2 For Admin");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice > 2 || choice < 0)
        {
            Console.WriteLine("Enter Valid Input");
        }
        string role;
        if (choice == 1)
        {
            role = "User";
        }
        else
        {
            role = "Admin";
        }

        Users users = new Users();
        users.Name = name;
        users.Email = email;
        users.Password = password;
        users.Role = role;
        userService.AddUserService(users);
    }
}