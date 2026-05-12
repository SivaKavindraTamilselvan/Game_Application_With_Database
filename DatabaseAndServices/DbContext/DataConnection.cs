using Npgsql;
namespace WordGame.DBContext;

public class DataConnection
{
    private readonly string db_connection_string = "Host=localhost;Port=5432;Database=WordGame;Username=sivakavindra;Password=SivaKavindra@280804";
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(db_connection_string);
    }
}