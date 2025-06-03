using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.UnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<TaskModel> Tasks { get; }
    Task<int> SaveChangesAsync();
}