namespace WordGame.Exceptions;

//custome password exception
public class PasswordException : Exception
{
    public PasswordException(string message) : base(message) {}
}