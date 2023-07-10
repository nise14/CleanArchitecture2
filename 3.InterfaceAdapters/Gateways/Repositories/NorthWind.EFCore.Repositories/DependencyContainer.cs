namespace NorthWind.EFCore.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services,
        IConfiguration configuration,
        string connectionString)
    {
        services.AddDbContext<NorthWindSalesContext>(
            options => options.UseSqlServer(configuration.GetConnectionString(connectionString)));

        services.AddScoped<INorthWindSalesCommandsRepository, NorthWindSalesCommandsRepository>();

        return services;
    }
}