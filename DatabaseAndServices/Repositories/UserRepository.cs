using WordGame.Models;
using WordGame.DBContext;
using Npgsql;
using System.Data;
using WordGame.Exceptions;
using WordGame.Interfaces;

namespace WordGame.Repositories;

public class UserRepository : AbstractRepository<int, Users>
{
    NpgsqlConnection connection;
    public UserRepository()
    {
        connection = dataConnection.GetConnection();
    }
    public override Users Create(Users item)
    {
        string query = $"INSERT INTO Users(Name,Email,Password,Role) VALUES ('{item.Name}','{item.Email}','{item.Password}','{item.Role}') RETURNING *";
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
                Users createdUser = new Users();
                createdUser.userId = Convert.ToInt32(reader["userId"]);
                createdUser.Email = reader["Email"].ToString() ?? "";
                createdUser.Role = reader["Role"].ToString() ?? "";
                createdUser.Name = reader["Name"].ToString() ?? "";
                createdUser.Password = reader["Password"].ToString() ?? "";
                Console.WriteLine("User created Successfully");
                return createdUser;
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

    public Users? LoginUser(string email, string password)
    {
        string query = $"SELECT * FROM Users WHERE Email = '{email}' AND Password = '{password}'";
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
                Users createdUser = new Users();
                createdUser.userId = Convert.ToInt32(reader["userId"]);
                createdUser.Email = reader["Email"].ToString() ?? "";
                createdUser.Role = reader["Role"].ToString() ?? "";
                createdUser.Name = reader["Name"].ToString() ?? "";
                createdUser.Password = reader["Password"].ToString() ?? "";
                Console.WriteLine("User Logged in Successfully");
                return createdUser;
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
        return null;
    }

    public List<UserHistoryDto> UserHistory(string email)
    {
        List<UserHistoryDto> historyList = new List<UserHistoryDto>();
        string query = $"SELECT u.userId,u.Name,u.Email,g.gameId,g.hiddenword,g.max_attempt,g.createdAt,w.guessedword,s.score,s.attempt,s.status from Users u JOIN GameModel g ON u.userId = g.userId JOIN WordGuessHistory w ON w.gameId = g.gameId JOIN ScoresModel s ON s.gameId = g.gameId WHERE Email = '{email}'";
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        try
        {
            connection.Open();

            NpgsqlDataReader reader = command.ExecuteReader();

            Dictionary<int, UserHistoryDto> gameMap = new Dictionary<int, UserHistoryDto>();

            while (reader.Read())
            {
                int gameId = Convert.ToInt32(reader["gameId"]);

                if (!gameMap.ContainsKey(gameId))
                {
                    UserHistoryDto dto = new UserHistoryDto();

                    dto.userId = Convert.ToInt32(reader["userId"]);

                    dto.Name = reader["Name"].ToString() ?? "";

                    dto.Email = reader["Email"].ToString() ?? "";

                    dto.gameId = gameId;

                    dto.hiddenWord = reader["hiddenword"].ToString() ?? "";

                    dto.max_attempt = Convert.ToInt32(reader["max_attempt"]);

                    dto.createdAt = Convert.ToDateTime(reader["createdAt"]);

                    dto.score = Convert.ToInt32(reader["score"]);

                    dto.attempt = Convert.ToInt32(reader["attempt"]);

                    dto.status = reader["status"].ToString() ?? "";
                    gameMap.Add(gameId, dto);
                }

                string guessed = reader["guessedword"].ToString() ?? "";

                gameMap[gameId].guessedWord.Add(guessed);
            }
            historyList = gameMap.Values.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return historyList;
    }

}