using Mvs.Data.Access.EF.Repositories;
using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Logic.Services;

namespace Mvs.Application.StartupConfiguration;

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