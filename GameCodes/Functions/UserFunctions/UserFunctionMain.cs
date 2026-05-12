using WordGame.IO;
using WordGame.Service;
using WordGame.Models;

namespace WordGame.Functions;

public partial class UserFunctions
{
    protected readonly UserService userService;
    InputsCheck inputsCheck = new InputsCheck();
    public UserFunctions(UserService _userService)
    {
        userService = _userService;
    }
}