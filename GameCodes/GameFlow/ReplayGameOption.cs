namespace WordGame.GameFlow;

public partial class Game
{
    public bool Replay()
    {
        Console.WriteLine("Enter 1 To Replay. Or any other input to exit");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice != 1)
        {
            return false;
        }
        else
        {
            inputsAndOutputs.ChooseDifficulty();
            int level = Convert.ToInt32(Console.ReadLine());
            while (level < 1 || level > 3)
            {
                Console.WriteLine("Invalid Input.Enter the correct input.");
                level = Convert.ToInt32(Console.ReadLine());
            }
            if (level == 1)
            {
                //easy
                max_attempt = 6;
            }
            else if (level == 2)
            {
                //medium
                max_attempt = 5;
            }
            else if (level == 3)
            {
                //hard
                max_attempt = 4;
            }
        }
        return true;
    }
}
