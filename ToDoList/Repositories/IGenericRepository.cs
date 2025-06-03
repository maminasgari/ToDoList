namespace ToDoList.Repositories;

public interface IGenericRepository<T> where T : class 
{
    Task<List<T>?> GetAllAsync(int pageId, int pageSize);
    Task<T?> FindByIdAsync(Guid id , bool tracking);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> GetTotalCountAsync();
}