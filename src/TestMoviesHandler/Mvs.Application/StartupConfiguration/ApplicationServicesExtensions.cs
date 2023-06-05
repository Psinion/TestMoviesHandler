using Mvs.Application.Middlewares;
using Mvs.Data.Access.EF.Repositories;
using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Logic.Services;

namespace Mvs.Application.StartupConfiguration;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ErrorHandlerMiddleware>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IActorsRepository, ActorsRepository>();
        services.AddScoped<IMoviesRepository, MoviesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddSingleton<ITokenService, TokenService>();
        services.AddScoped<ICredentialsService, CredentialsService>();
        services.AddScoped<IUsersService, UsersService>();

        return services;
    }
}