namespace NorthWind.Sales.Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderPresenter>();

        services.AddScoped<ICreateOrderPresenter>(
            provider => provider.GetRequiredService<CreateOrderPresenter>());

        services.AddScoped<ICreateOrderOutputPort>(
            provider => provider.GetRequiredService<CreateOrderPresenter>());

        return services;
    }
}