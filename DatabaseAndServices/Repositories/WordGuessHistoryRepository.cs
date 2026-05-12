using WordGame.Models;
using WordGame.DBContext;
using Npgsql;
using System.Data;
using WordGame.Exceptions;
using WordGame.Interfaces;

namespace WordGame.Repositories;

public class WordGuessHistoryRepository : AbstractRepository<int, WordGuessHistory>
{
    NpgsqlConnection connection;
    public WordGuessHistoryRepository()
    {
        connection = dataConnection.GetConnection();
    }
    public override WordGuessHistory Create(WordGuessHistory item)
    {
        string query = $"INSERT INTO WordGuessHistory(gameId,guessedWord) VALUES ('{item.gameId}','{item.guessedWord}') RETURNING *";
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        try
        {
            //connection is opened
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //new object is created
                WordGuessHistory createdGame = new WordGuessHistory();
                createdGame.historyId = Convert.ToInt32(reader["historyId"]);
                createdGame.gameId = Convert.ToInt32(reader["gameId"]);
                createdGame.createdAt = Convert.ToDateTime(reader["createdAt"]);
                createdGame.guessedWord = reader["guessedWord"].ToString() ?? "";
                Console.WriteLine("Game History created Successfully");
                return createdGame;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return null!;
    }
}