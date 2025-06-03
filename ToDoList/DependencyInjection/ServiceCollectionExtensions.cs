using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.UnitOfWork;

namespace ToDoList.DependencyInjection;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ToDoConnSt")));

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;
    }

}