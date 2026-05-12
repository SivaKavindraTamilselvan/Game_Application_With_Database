using WordGame.Exceptions;

namespace WordGame.Validation;

public class PasswordValidation
{
    //validation function created for checking the inputs
    public static void isValidPassword(string password)
    {
        //check for whitespace
        if(password.Trim() == "")
        {
            throw new PasswordException("Password cannot be empty");
        }
        //check if the password greater than length 12
        if(password.Length<8)
        {
            throw new PasswordException("Password Length cannot be less than 8.");
        }
        //check if the password lesser than length 12
        if(password.Length>12)
        {
            throw new PasswordException("Password Length cannot be greater than 12");
        }
        //addition of symbols and numbers as strong password will be implemented in future
    }
}