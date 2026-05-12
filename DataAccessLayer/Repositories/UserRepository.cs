using WordGame.Models;
using WordGame.DBContext;
using System.Data;
namespace WordGame.DataAccess;

public class UserRepository
{
    DataConnection dataConnection = new DataConnection();
    NpgsqlConnection connection;
    public UserRepository()
    {
        connection = dataConnection.GetConnection();
    }

    public void Create(Users users)
    {
        string query = $"INSERT INTO Users(Name,Email,PhoneNumber) VALUES ('{users.Name}','{users.Email}','{users.PhoneNumber}')";
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
    }
}