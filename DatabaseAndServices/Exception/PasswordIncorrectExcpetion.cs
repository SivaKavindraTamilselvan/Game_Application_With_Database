namespace WordGame.Exceptions;

// custom password exception
public class PasswordIncorrectException : Exception
{
    private static string message = "Password incorrect. Enter correct password. Try Again";

    public PasswordIncorrectException() : base(message)
    {
    }
}