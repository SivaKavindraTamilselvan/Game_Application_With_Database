using WordGame.Models;
using WordGame.DBContext;
using WordGame.DataAccess;
using Npgsql;
using System.Data;
using WordGame.Exceptions;

namespace WordGame.DataAccess;

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