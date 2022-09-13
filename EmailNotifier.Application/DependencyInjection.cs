using EmailNotifier.EmailService;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmailNotifier.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var smtpSection = configuration.GetSection("SmtpSettings");
        services.AddSingleton(new EmailSender(
            new EmailSenderOptions()
            {
                Host = smtpSection["Host"],
                Port = int.Parse(smtpSection["Port"]),
                UseSSL = bool.Parse(smtpSection["UseSSL"]),
                Login = smtpSection["Login"],
                Password = smtpSection["Password"]
            }));

        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
