namespace WordGame.Models;

public class Words
{
    public int wordId {get;set;}
    public int Number_of_letter {get;set;}
    public string Word {get;set;} = "";

    public override string ToString()
    {
        return $"WordId : {wordId}\nNumber_Of_Letter : {Number_of_letter}\nWord : {Word}";
    }
}