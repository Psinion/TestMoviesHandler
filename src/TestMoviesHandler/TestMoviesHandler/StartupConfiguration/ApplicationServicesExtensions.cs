using TestMoviesHandler.Data.Repositories;
using TestMoviesHandler.Data.Repositories.Base;
using TestMoviesHandler.Data.Services;
using TestMoviesHandler.Data.Services.Base;

namespace TestMoviesHandler.StartupConfiguration;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IActorsRepository, ActorsRepository>();
        services.AddScoped<IMoviesRepository, MoviesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddScoped<IUsersService, UsersService>();
        return services;
    }
}