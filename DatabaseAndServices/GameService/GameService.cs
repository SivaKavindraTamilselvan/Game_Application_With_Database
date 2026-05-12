using WordGame.Models;
using WordGame.Interfaces;
using WordGame.Repositories;

namespace WordGame.Service;

public class GameService
{
    protected readonly GameRepository gameRepository;
    protected readonly ScoreRepository scoreRepository;
    protected readonly WordGuessHistoryRepository wordGuessHistoryRepository;
    public GameService(GameRepository _gameRepository, WordGuessHistoryRepository _wordGuessHistoryRepository,ScoreRepository _scoreRepository)
    {
        gameRepository = _gameRepository;
        wordGuessHistoryRepository = _wordGuessHistoryRepository;
        scoreRepository = _scoreRepository;
    }

    public GameModel AddGameService(GameModel gameModel)
    {
        var createdGame = gameRepository.Create(gameModel);
        return createdGame;
    }
    public WordGuessHistory AddWordGuessService(WordGuessHistory wordGuessHistory)
    {
        var history = wordGuessHistoryRepository.Create(wordGuessHistory);
        return history;
    }
    public ScoresModel AddScoresService(ScoresModel scoreModel)
    {
        var scores = scoreRepository.Create(scoreModel);
        return scores;
    }
}