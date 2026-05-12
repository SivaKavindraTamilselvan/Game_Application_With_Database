namespace WordGame.Models;

public class UserHistoryDto
{
    public int userId { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public int gameId { get; set; }
    public string hiddenWord { get; set; } = "";
    public int max_attempt { get; set; }
    public DateTime createdAt { get; set; }
    public string status { get; set; } = "";
    public int score { get; set; }
    public int attempt { get; set; }
    public List<string> guessedWord { get; set; } = new List<string>();

    public override string ToString()
    {
        return $"User Id : {userId}\nName : {Name}\nEmail : {Email}\nGame Id : {gameId}\nHidden Word : {hiddenWord}\nMax Attempt : {max_attempt}\nScore : {score}\nAttempt : {attempt}\nStatus : {status}\nCreated At : {createdAt}\nGuessed Words : {string.Join(", ", guessedWord)}";
    }
}