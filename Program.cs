using WordGame.GameFlow;
using WordGame.Service;
using DotNetEnv;
using WordGame.Models;
using WordGame.Exceptions;


public class Program
{
    static void Main(string[] args)
    {
        Env.Load();
        int choice;
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Enter 1 To Register User");
        Console.WriteLine("Enter 2 For Login And Play The Game");
        Console.WriteLine("---------------------------------------------");
        while (!int.TryParse(Console.ReadLine(), out choice) || choice > 2 || choice < 0)
        {
            Console.WriteLine("Enter Valid Input");
        }
        try
        {
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Register Panel");
                        UserService user = new UserService();
                        user.AddUser();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Login Panel and Play the Game");
                        UserService user = new UserService();
                        var loginUser = user.LoginUser();
                        if (loginUser == null)
                        {
                            throw new UserNotFoundException();
                        }
                        Game game = new Game();
                        game.Start();
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        /*
        Game game = new Game();
        game.Start();
        */
    }
}