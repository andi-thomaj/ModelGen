using ModelGen.Application;
using ModelGen.Infrastructure;

namespace ModelGen.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRouting(options => { options.LowercaseUrls = true; });
        // services.AddAuthentication().AddGoogle(options =>
        // {
        //     options.ClientId = configuration["GoogleAuthentication:ClientId"]!;
        //     options.ClientSecret = configuration["GoogleAuthentication:ClientSecret"]!;
        // });
        
        services
            .AddInfrastructure(configuration)
            .AddApplication();

        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}