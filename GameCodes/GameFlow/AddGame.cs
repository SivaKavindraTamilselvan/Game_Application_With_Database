using WordGame.Exceptions;
using WordGame.Validation;
using WordGame.WordGenerator;
using WordGame.Feedback;
using WordGame.Scores;
using WordGame.IO;
using WordGame.Models;
using WordGame.Interfaces;
using WordGame.Repositories;

namespace WordGame.GameFlow;

public partial class Game
{
    public GameModel AddGameService(Users user)
    {
        GameModel gameModel = new GameModel();
        gameModel.userId = user.userId;
        gameModel.max_attempt = max_attempt;
        gameModel.hiddenWord = secretWord;
        var game = gameService.AddGameService(gameModel);
        return game;
    }
}