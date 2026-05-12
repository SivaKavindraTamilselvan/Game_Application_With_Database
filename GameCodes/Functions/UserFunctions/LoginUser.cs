using WordGame.Exceptions;
using WordGame.Models;

namespace WordGame.Functions;

public partial class UserFunctions
{
    public Users? LoginUser()
    {

        Console.WriteLine("Enter the Used Details To Login");
        Console.WriteLine();

        Console.WriteLine("Enter Your Email");
        string email = inputsCheck.EmailInputs();
        if (userService.GetUsersByEmail(email) == null)
        {
            throw new UserNotFoundException();
        }

        Console.WriteLine("Enter Your Password");
        string password = inputsCheck.PasswordInputs();

        Users loginUser = userService.LoginUser(email, password);
        return loginUser;
    }
}