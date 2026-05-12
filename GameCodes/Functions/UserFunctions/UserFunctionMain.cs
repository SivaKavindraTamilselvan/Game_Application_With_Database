using WordGame.IO;
using WordGame.Service;
using WordGame.Models;
using WordGame.GameFlow;

namespace WordGame.Functions;

public partial class UserFunctions
{
    protected readonly UserService userService;
    protected readonly GameService gameService;
    private readonly Game game;
    private readonly InputsCheck inputsCheck;
    public UserFunctions(UserService _userService,GameService _gameService)
    {
        userService = _userService;
        gameService = _gameService;

        game = new Game(_gameService);
        inputsCheck = new InputsCheck();
    }
}