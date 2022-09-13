using EmailNotifier.Persistence;

namespace EmailNotifier.WebAPI;

public static class Configuration
{
    public static void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<EmailNotifierContext>();

        db.Database.EnsureCreated();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
