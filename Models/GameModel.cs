
namespace WordGame.Models;

public class GameModel
{
    public int gameId {get;set;}
    public int userId {get;set;}
    public string hiddenWord {get;set;} = "";
    public int max_attempt {get;set;}
    public int score {get;set;}
    public string status {get;set;} = "";
    public DateTime createdAt {get;set;}

    public override string ToString()
    {
        return$"Game Id : {gameId}\nUser Id : {userId}\nHiddenWord : {hiddenWord}\nMaximum Attemp : {max_attempt}";
    }
}