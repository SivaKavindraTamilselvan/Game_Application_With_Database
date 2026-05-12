using WordGame.DBContext;
using WordGame.Models;

namespace WordGame.DataAccess;

public abstract class AbstractRepository<K,T> : IRepository<K,T> where T: class where K : notnull
{
    public abstract T Create(T item);

    protected readonly DataConnection dataConnection = new ();


}