var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

Configure(app);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void Configure(WebApplication webApp)
{
    webApp.UseSwagger();
    webApp.UseSwaggerUI();
}