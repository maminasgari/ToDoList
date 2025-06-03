using Microsoft.EntityFrameworkCore;
using ToDoList.Data;

namespace ToDoList.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class 
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _dbSet = context.Set<T>();
    }
    public async Task<List<T>?> GetAllAsync(int pageId, int pageSize )
    {
        var tasks = await _dbSet
            .Skip((pageId - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            
        return tasks;
    }

    public async Task<T?> FindByIdAsync(Guid id, bool tracking)
    {
        var task = await _dbSet.FindAsync(id);

        if (tracking && task is not null)
        {
            _dbSet.Entry(task).State = EntityState.Detached;
        }

        return task;
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _dbSet.CountAsync();
    }
}