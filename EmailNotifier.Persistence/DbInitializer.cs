namespace EmailNotifier.Persistence;

public class DbInitializer
{
    public async static void Initialize(EmailNotifierContext context)
    {
        await context.Database.EnsureCreatedAsync();
    }
}
