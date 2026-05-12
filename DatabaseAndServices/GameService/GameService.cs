using WordGame.Models;
using WordGame.Interfaces;
using WordGame.Repositories;

namespace WordGame.Service;

public class GameService
{
    protected readonly GameRepository gameRepository;

    protected readonly WordGuessHistoryRepository wordGuessHistoryRepository;
    public GameService(GameRepository _gameRepository,WordGuessHistoryRepository _wordGuessHistoryRepository)
    {
        gameRepository = _gameRepository;
        wordGuessHistoryRepository = _wordGuessHistoryRepository;
    }
    
    public GameModel AddGameService(GameModel gameModel)
    {
        var createdGame = gameRepository.Create(gameModel);
        Console.WriteLine(createdGame);
        return createdGame;
    }
    public WordGuessHistory AddWordGuessService(WordGuessHistory wordGuessHistory)
    {
        var history = wordGuessHistoryRepository.Create(wordGuessHistory);
        Console.WriteLine(history);
        return history;
    }
}