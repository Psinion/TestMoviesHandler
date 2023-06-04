using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Mvs.Application.Middlewares;
using Mvs.Data.Access.EF.Contexts;

namespace Mvs.Application.StartupConfiguration;

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

        services.AddSwaggerGen();

        services.AddDbContext<MoviesDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddCors(options =>
        {
            var clientUrl = Configuration.GetValue<string>("ClientUrl");

            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(clientUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        services.AddApplicationServices();

        //services.AddControllersWithViews()
        //    .AddJsonOptions(options =>
        //    {
        //        options
        //            .JsonSerializerOptions
        //            .ReferenceHandler = ReferenceHandler.IgnoreCycles;
        //    });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseCookiePolicy(new CookiePolicyOptions()
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        });

        app.UseCors();

        app.UseMiddleware<JwtMiddleware>();

        app.UseEndpoints(endpoints =>
            endpoints.MapControllers()
        );
    } 
}