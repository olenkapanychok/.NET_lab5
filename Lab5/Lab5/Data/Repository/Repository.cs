using Microsoft.EntityFrameworkCore;

namespace Lab5.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    public Repository(AppDbContext context)
    {
        Context = context;
    }

    public T? Get(int id) => Context.Set<T>().Find(id);
    public IEnumerable<T>? GetAll() => Context.Set<T>().ToList();
    public void Add(T entity) => Context.Set<T>().Add(entity);
    public void Update(int id, T entity)
    {
        var existedEntity = Get(id);
        if (existedEntity != null)
        {
            var entityType = Context.Model.FindEntityType(typeof(T));
            var key = entityType.FindPrimaryKey();
            var currId = key.Properties[0];
            currId.PropertyInfo.SetValue(entity, id);
            Context.Entry(existedEntity).CurrentValues.SetValues(entity);
            Context.Entry(existedEntity).State = EntityState.Modified;
        }
    }

    public void Remove(T entity) => Context.Set<T>().Remove(entity);
}