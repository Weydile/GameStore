namespace GameStore.DAL.Repository;

using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;
using Microsoft.EntityFrameworkCore;


public class DefaultRepository<T> : IDefaultRepository<T>
        where T : DefaultEntity
{
    public DatabaseContext _context = new DatabaseContext();

    public bool Add(T item)
    {
        if (IsExist(item.Id))
            return false;
        _context.Entry(item).State = EntityState.Added;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(T item)
    {
        if (!IsExist(item.Id))
            return false;
        _context.Entry(item).State = EntityState.Deleted;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        return Delete(Get(id));
    }

    public bool Edit(T item)
    {
        if (!IsExist(item.Id))
            return false;
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
        return true;
    }
    public bool IsExist(int id)
    {
        return _context.Set<T>().Find(id) != null;
    }
    public T Get(int id)
    {
        var entity = _context.Set<T>().Find(id);
        _context.Entry(entity).Reload();
        return entity;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }

    public DatabaseContext GetContext()
    {
        return _context;
    }
}

