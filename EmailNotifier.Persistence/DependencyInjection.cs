using EmailNotifier.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailNotifier.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<EmailNotifierContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IEmailNotifierContext>(provider => provider.GetService<EmailNotifierContext>());

        return services;
    }
}
