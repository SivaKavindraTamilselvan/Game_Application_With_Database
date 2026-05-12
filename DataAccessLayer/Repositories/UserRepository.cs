using WordGame.Models;
using WordGame.DBContext;
using WordGame.DataAccess;
using Npgsql;
using System.Data;

namespace WordGame.DataAccess;

public class UserRepository : AbstractRepository<int, Users>
{
    //DataConnection dataConnection = new DataConnection();
    NpgsqlConnection connection;
    public UserRepository()
    {
        connection = dataConnection.GetConnection();
    }

    public override Users Create(Users item)
    {
        string query = $"INSERT INTO Users(Name,Email,Password,Role) VALUES ('{item.Name}','{item.Email}','{item.Password}','{item.Role}')";
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            if(result>0)
            {
                Console.WriteLine("User Added Successfully");
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