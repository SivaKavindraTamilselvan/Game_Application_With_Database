using WordGame.Models;
using WordGame.DBContext;
using Npgsql;
using System.Data;
using WordGame.Exceptions;
using WordGame.Interfaces;

namespace WordGame.Repositories;

public class WordRepository : AbstractRepository<int, Words>
{
    NpgsqlConnection connection;
    public WordRepository()
    {
        connection = dataConnection.GetConnection();
    }
    public override Words Create(Words item)
    {
        string query = $"";
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
                Words createdUser = new Words();
               
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

    public Users? LoginUser(string email,string password)
    {
        string query  = $"SELECT * FROM Users WHERE Email = '{email}' AND Password = '{password}'";
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
}