using WordGame.Models;
using WordGame.DBContext;
using Npgsql;
using System.Data;
using WordGame.Exceptions;
using WordGame.Interfaces;

namespace WordGame.Repositories;

public class GameRepository : AbstractRepository<int, GameModel>
{
    NpgsqlConnection connection;
    public GameRepository()
    {
        connection = dataConnection.GetConnection();
    }
    public override GameModel Create(GameModel item)
    {
        string query = $"INSERT INTO GameModel(userId,hiddenword,max_attempt) VALUES ('{item.userId}','{item.hiddenWord}','{item.max_attempt}') RETURNING *";
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
                GameModel createdGame = new GameModel();
                createdGame.userId = Convert.ToInt32(reader["userId"]);
                createdGame.gameId = Convert.ToInt32(reader["gameId"]);
                createdGame.createdAt = Convert.ToDateTime(reader["createdAt"]);
                createdGame.hiddenWord = reader["hiddenword"].ToString();
                createdGame.max_attempt = Convert.ToInt32(reader["max_attempt"]);
                Console.WriteLine("Game created Successfully");
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