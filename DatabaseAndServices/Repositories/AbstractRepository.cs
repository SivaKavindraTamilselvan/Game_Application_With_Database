using WordGame.DBContext;
using WordGame.Models;
using Npgsql;
using WordGame.Interfaces;

namespace WordGame.Repositories;

public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class ,new () where K : notnull
{
    NpgsqlConnection connection;
    public AbstractRepository()
    {
        connection = dataConnection.GetConnection();
    }
    public abstract T Create(T item);

    public List<T> GetAll()
    {
        string tablename = typeof(T).Name;
        string query = $"SELECT * FROM {tablename}";
        List<T> list = new List<T>();
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        try
        {
            //connection is opened
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //new object is created
                T item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(item, reader[prop.Name]);
                }
                list.Add(item);
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
        return list;
    }

    protected readonly DataConnection dataConnection = new();


}