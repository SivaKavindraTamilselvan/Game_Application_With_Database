namespace WordGame.Models;

// used for the users registraton
public class Users
{
    public int userId {get;set;}
    public string Name {get;set;} = "";
    public string Email {get;set;} = "";
    public string Password {get;set;} = "";
    public string Role {get;set;} = "";

    public override string ToString()
    {
        return $"User Id : {userId}\nName : {Name}\nEmail : {Email}\nPassword : {Password}\nRole : {Role}";
    }
}