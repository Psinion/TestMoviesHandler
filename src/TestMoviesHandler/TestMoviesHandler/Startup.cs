using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TestMoviesHandler.Data;

namespace TestMoviesHandler;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<MoviesDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddCors(options =>
        {
            var clientUrl = Configuration.GetValue<string>("ClientUrl");

            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(clientUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options
                    .JsonSerializerOptions
                    .ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
            endpoints.MapControllers()
        );
    } 
}