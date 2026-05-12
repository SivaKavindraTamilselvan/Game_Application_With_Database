namespace WordGame.Exceptions;

//custome email exception
public class NameException : Exception
{
    private static string message = "Name Cannot be Empty.Invalid Name Format";
    public NameException() : base(message) {}
}