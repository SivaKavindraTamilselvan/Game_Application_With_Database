namespace WordGame.Exceptions;

public class UserRegisteredException : Exception
{
    private static string message = "User Already Registered with this email";
    public UserRegisteredException() : base(message)
    {
        
    }
}