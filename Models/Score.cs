using System.Security.Cryptography.X509Certificates;

namespace WordGame.Models;

public class Scores
{
    public int scoreId {get;set;}
    public int gameId{get;set;}
    public int userId {get;set;}
    public string status {get;set;} = "";
    public int score {get;set;}
    public DateTime createdAt {get;set;}
    public DateTime updatedAt {get;set;}
}