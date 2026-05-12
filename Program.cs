using WordGame.GameFlow;
using WordGame.Service;
public class Program
{
    static void Main(string[] args)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 2 || choice > 0)
        {
            Console.WriteLine("Enter Valid Input");
        }
        while (true)
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
                        Console.WriteLine("Login Panel");
                        break;
                    }
            }
        }

        User user = new User();
        Game game = new Game();
        game.Start();
    }
}