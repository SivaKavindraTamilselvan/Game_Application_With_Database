using WordGame.GameFlow;
using WordGame.Service;
using DotNetEnv;
using WordGame.Models;
using WordGame.Exceptions;
using WordGame.WordGenerator;
using WordGame.Repositories;
using WordGame.Functions;

public class Program
{
    static void Main(string[] args)
    {
        
        Env.Load();

        UserRepository userRepository = new UserRepository();

        UserService userService = new UserService(userRepository);

        UserFunctions userFunctions = new UserFunctions(userService);

        while (true)
        {
            int choice;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enter 1 To Register User");
            Console.WriteLine("Enter 2 For Login And Play The Game And Know The History Of The User");
            Console.WriteLine("Enter 0 To Quit The Loop");
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
                            userFunctions.AddUser();
                            break;
                        }
                    case 2:
                        {
                            WordProvider provider = new WordProvider();
                            Console.WriteLine("Login Panel and Play the Game");
                            var loginUser = userService.LoginUser();
                            if (loginUser == null)
                            {
                                throw new UserNotFoundException();
                            }
                            userService.UserHistory(loginUser);
                            Game game = new Game();
                            game.Start(loginUser);
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
        }

        /*
        Game game = new Game();
        game.Start();
        */
    }
}