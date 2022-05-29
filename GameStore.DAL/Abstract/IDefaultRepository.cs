namespace GameStore.DAL.Abstract;
using GameStore.DAL.Entites;
public interface IDefaultRepository<T> where T : DefaultEntity
{
    /// <summary>
    /// Добавить
    /// </summary>
    public bool Add(T item);

    /// <summary>
    /// Изменить
    /// </summary>
    public bool Edit(T item);

    /// <summary>
    /// Удалить
    /// </summary>
    public bool Delete(int id);

    /// <summary>
    /// Удалить
    /// </summary>
    public bool Delete(T item);

    /// <summary>
    /// Проверить существует ли запись
    /// </summary>
    public bool IsExist(int id);

    /// <summary>
    /// Найти по Id
    /// </summary>
    public T Get(int id);

    /// <summary>
    /// Получить всё
    /// </summary>
    public IQueryable<T> GetAll();

}

