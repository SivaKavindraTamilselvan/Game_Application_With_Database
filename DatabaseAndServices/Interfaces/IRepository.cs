namespace WordGame.DataAccess;

public interface IRepository<K, T> where T : class
{
    public T Create(T item);
    public List<T> GetAll();

    //need to be implemented but now not the requirements mentioned
    // public T? Get(K key);
    // public T? Update(K key,T item);
    // public T Delete(K key);
}