using EmailNotifier.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Services.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configuration.Configure(app);

app.Run();
