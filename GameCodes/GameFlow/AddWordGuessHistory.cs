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
    public WordGuessHistory AddWordGuessService(GameModel game,string guessed_word)
    {
        WordGuessHistory wordGuessHistory = new WordGuessHistory();
        wordGuessHistory.gameId = game.gameId;
        wordGuessHistory.guessedWord = guessed_word;
        var history = gameService.AddWordGuessService(wordGuessHistory);
        return history;
    }
}