using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IGenericRepository<TaskModel> Tasks { get; }
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Tasks = new GenericRepository<TaskModel>(_context);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}