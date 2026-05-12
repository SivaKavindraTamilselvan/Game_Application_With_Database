using WordGame.Exceptions;
using WordGame.Validation;
using WordGame.WordGenerator;
using WordGame.Feedback;
using WordGame.Scores;
using WordGame.IO;
using WordGame.Models;
using WordGame.Interfaces;
using WordGame.Repositories;
using WordGame.Service;

namespace WordGame.GameFlow;

public partial class Game
{
    private int max_attempt = 6;
    private string secretWord = "";
    //validation of input
    GuessValidator validator = new GuessValidator();
    //generate random words
    WordProvider generator = new WordProvider();
    //compare the guessed words and secret word and print feedback
    FeedbackGenerator feedback = new FeedbackGenerator();
    //calculate the scores
    Score scoresCalucaltor = new Score();
    //for console statements
    InputsAndOutputs inputsAndOutputs = new InputsAndOutputs();
    protected readonly GameService gameService;

    public Game (GameService _gameService)
    {
        gameService = _gameService;
    }
}