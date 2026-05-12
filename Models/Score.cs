
namespace WordGame.Models;

public class Scores
{
    public int scoreId {get;set;}
    public int gameId{get;set;}
    public int userId {get;set;}
    public string status {get;set;} = "";
    public int score {get;set;}
    public int attempt {get;set;}
    public DateTime createdAt {get;set;}

    public override string ToString()
    {
        return $"ScoreId : {scoreId}\nGameId : {gameId}\nUserId : {userId}\nStatus : {status}\nScore : {score}\nAttempt : {attempt}\ncraetedAt : {createdAt}";
    }
}