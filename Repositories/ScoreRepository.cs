using WordGame.Models;
using WordGame.DBContext;
using WordGame.DataAccess;
using Npgsql;
using System.Data;
using WordGame.Exceptions;

namespace WordGame.DataAccess;

public class ScoreRepository : AbstractRepository<int, ScoresModel>
{
    NpgsqlConnection connection;
    public ScoreRepository()
    {
        connection = dataConnection.GetConnection();
    }
    public override ScoresModel Create(ScoresModel item)
    {
        string query = $"INSERT INTO ScoresModel(gameId,userId,status,score,attempt) VALUES ('{item.gameId}','{item.userId}','{item.status}','{item.score}','{item.attempt}') RETURNING *";
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
                ScoresModel createdScore = new ScoresModel();
                createdScore.scoreId = Convert.ToInt32(reader["scoreId"]);
                createdScore.gameId = Convert.ToInt32(reader["gameId"]);
                createdScore.userId = Convert.ToInt32(reader["userId"]);
                createdScore.createdAt = Convert.ToDateTime(reader["createdAt"]);
                createdScore.status = reader["status"].ToString();
                createdScore.score = Convert.ToInt32(reader["score"]);
                createdScore.attempt = Convert.ToInt32(reader["attempt"]);
                Console.WriteLine("Game History created Successfully");
                return createdScore;
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