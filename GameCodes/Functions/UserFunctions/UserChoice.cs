using WordGame.Exceptions;
using WordGame.Models;
using WordGame.GameFlow;

namespace WordGame.Functions;

public partial class UserFunctions
{
    public void UserChoiceFunction(Users user)
    {
        while (true)
        {
            int choice;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enter 1 To Play The Game");
            Console.WriteLine("Enter 2 To Show The History");
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
                            game.Start(user);
                            break;
                        }
                    case 2:
                        {
                            userService.UserHistory(user);
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