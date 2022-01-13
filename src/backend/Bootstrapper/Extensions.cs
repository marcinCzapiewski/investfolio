using Investfolio.Modules.Quotes.Api;

namespace Investfolio.Bootstrapper
{
    internal static class Extensions
    {
        public static IServiceCollection AddInvestfolioLogic(this IServiceCollection services)
        {
            services.AddQuotes();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication UseSwaggerApiDocumentation(this WebApplication webApp)
        {
            webApp.UseSwagger();
            webApp.UseSwaggerUI();

            return webApp;
        }
    }
}
