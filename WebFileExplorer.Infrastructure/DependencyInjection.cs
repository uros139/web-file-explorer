using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Infrastructure.Database;

namespace WebFileExplorer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration) =>
    services
        .AddDatabase(configuration)
        .AddRepositories();

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) => services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
}
