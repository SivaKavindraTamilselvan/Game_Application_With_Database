namespace WordGame.Exceptions;

//custome email exception
public class EmailException : Exception
{
    private static string message = "Invalid Email Format";
    public EmailException() : base(message) {}
}