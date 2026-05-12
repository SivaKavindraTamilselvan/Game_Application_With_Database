using WordGame.GameFlow;
using WordGame.Service;
using DotNetEnv;
using WordGame.Models;
using WordGame.Exceptions;
using WordGame.WordGenerator;
using WordGame.Repositories;
using WordGame.Functions;
using WordGame.Interfaces;

public class Program
{
    static void Main(string[] args)
    {

        Env.Load();

        UserRepository userRepository = new UserRepository();

        UserService userService = new UserService(userRepository);

        GameRepository gameRepository = new GameRepository();

        WordGuessHistoryRepository wordGuessHistoryRepository = new WordGuessHistoryRepository();

        ScoreRepository scoreRepo = new ScoreRepository();

        GameService gameService = new GameService(gameRepository, wordGuessHistoryRepository, scoreRepo);

        UserFunctions userFunctions = new UserFunctions(userService, gameService);

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
                            Console.WriteLine("Login Panel and Play the Game");
                            var user = userFunctions.LoginUser();
                            if (user == null)
                            {
                                throw new PasswordIncorrectException();
                            }
                            userFunctions.UserChoiceFunction(user);
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
    }
}