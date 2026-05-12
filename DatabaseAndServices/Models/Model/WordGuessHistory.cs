namespace WordGame.Models;

// store all the guessed words of each game of the user
// used to maintain the history
public class WordGuessHistory
{
    public int historyId {get;set;}
    public int gameId {get;set;}
    public string guessedWord {get;set;} = "";
    public DateTime createdAt {get;set;}
    public override string ToString()
    {
        return $"HistoryId : {historyId}\nGameId : {gameId}\nGuessedWord : {guessedWord}\nCreatedAt : {createdAt}";
    }
}