namespace Lab5.Data.Repository;

public interface IRepository<T> where T : class
{
    T? Get(int id);
    IEnumerable<T>? GetAll();
    void Add(T entity);
    void Update(int id, T entity);
    void Remove(T entity);
}
