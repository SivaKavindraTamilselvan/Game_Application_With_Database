using WordGame.Validation;
namespace WordGame.IO;

public class InputsCheck
{
    //email input is checked and validated
    public string EmailInputs()
    {
        string email = Console.ReadLine() ?? string.Empty;
        //loop until valid entry is entered
        while(true)
        {
            try
            {
                //call validation function
                EmailValidation.isValidEmail(email);
                return email;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Email Address Again");
                email = Console.ReadLine() ?? "";
            }
        }
    }
    public string NameInputs()
    {
        string name = Console.ReadLine() ?? string.Empty;
        while(true)
        {
            try
            {
                //call validation function
                NameValidation.isValidName(name);
                return name;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Name Again");
                name = Console.ReadLine() ?? "";
            }
        }
    }

    public string PasswordInputs()
    {
        string password = Console.ReadLine() ?? string.Empty;
        while(true)
        {
            try
            {
                //call validation function
                PasswordValidation.isValidPassword(password);
                return password;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Password Again");
                password = Console.ReadLine() ?? "";
            }
        }
    }
    public int IdInputs()
    {
        Console.WriteLine("Enter Id");
        int id;
        //loop until valid entry is entered
        while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        return id;
    }
}