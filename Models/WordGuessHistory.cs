namespace WordGame.Models;

public class WordGuessHistory
{
    public int historyId {get;set;}
    public int gameId {get;set;}
    public int userId {get;set;}
    public string guessedWord {get;set;} = "";
    public DateTime craetedAt {get;set;} = DateTime.Now;
}