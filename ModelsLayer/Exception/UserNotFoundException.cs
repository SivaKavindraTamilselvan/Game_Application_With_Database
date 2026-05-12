namespace WordGame.Exceptions;

public class UserNotFoundException : Exception
{
    private static string message = "No User Is Found In The DataBase";
    public UserNotFoundException() : base(message)
    {
        
    }
}