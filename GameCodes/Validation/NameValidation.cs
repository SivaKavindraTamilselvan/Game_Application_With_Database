using WordGame.Exceptions;

namespace WordGame.Validation;

public class NameValidation
{
    //implementation of name validation by using regex pattern
    public static void isValidName(string name)
    {
        string checkName = name.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new NameException();
        }
    }
}