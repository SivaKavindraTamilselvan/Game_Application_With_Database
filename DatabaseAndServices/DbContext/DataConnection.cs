using Npgsql;
namespace WordGame.DBContext;
//usage of Npgsql Connection to connect to the database
public class DataConnection
{
    // need to enter correct usernme and password
    private readonly string db_connection_string = "Host=localhost;Port=5432;Database=WordGame;Username=username;Password=password";
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(db_connection_string);
    }
}