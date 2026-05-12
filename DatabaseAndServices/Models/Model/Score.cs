
namespace WordGame.Models;

// store the scores used as seperate because it is created only at the end of the game so seprate model is made and linked to the game model
public class ScoresModel
{
    public int scoreId { get; set; }
    public int gameId { get; set; }
    public int userId { get; set; }
    public string status { get; set; } = "";
    public int score { get; set; }
    public int attempt { get; set; }
    public DateTime createdAt { get; set; }

    public override string ToString()
    {
        return $"ScoreId : {scoreId}\nGameId : {gameId}\nUserId : {userId}\nStatus : {status}\nScore : {score}\nAttempt : {attempt}\ncraetedAt : {createdAt}";
    }
}