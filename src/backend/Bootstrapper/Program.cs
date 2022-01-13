using Investfolio.Bootstrapper;
using Investfolio.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddInfrastructure();
    services.AddInvestfolioLogic();
    services.AddSwagger();
}

void Configure(WebApplication webApp)
{
    webApp.UseInfrastructure();
    webApp.UseSwaggerApiDocumentation();
}