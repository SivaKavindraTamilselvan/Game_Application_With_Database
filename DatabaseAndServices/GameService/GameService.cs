using WordGame.Models;
using WordGame.Interfaces;
using WordGame.Repositories;

namespace WordGame.Service;

public class GameService
{
    protected readonly GameRepository gameRepository;
    public GameService(GameRepository _gameRepository)
    {
        gameRepository = _gameRepository;
    }
    
    public GameModel AddGameService(GameModel gameModel)
    {
        var createdGame = gameRepository.Create(gameModel);
        Console.WriteLine(createdGame);
        return createdGame;
    }
}