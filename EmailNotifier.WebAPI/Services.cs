using EmailNotifier.Application;
using EmailNotifier.Application.Common.Mappings;
using EmailNotifier.Application.Interfaces;
using EmailNotifier.Persistence;
using System.Reflection;

namespace EmailNotifier.WebAPI;

public static class Services
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IEmailNotifierContext).Assembly));
        });


        services.AddApplication(configuration);
        services.AddPersistence(configuration);
        services.AddControllers();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        services.AddSwaggerGen();
    }
}
