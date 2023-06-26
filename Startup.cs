using Microsoft.AspNetCore.Server.Kestrel.Core;
using Monty_Hall_API_V3.Services;
namespace Monty_Hall_API_V3.Startup;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add CORS policy
        services.AddCors(options =>
        {
            options.AddPolicy("MyAllowOriginPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        
        services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });

        // Other service configurations...
        services.AddControllers();
        services.AddScoped<ISimulationService, SimulationService>();
    }

    public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
    {
        // Enable CORS
        app.UseCors("MyAllowOriginPolicy");

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        // Other middleware configurations...
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}