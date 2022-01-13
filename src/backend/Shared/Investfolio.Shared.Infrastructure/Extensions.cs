using Investfolio.Shared.Infrastructure.Api;
using Investfolio.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Investfolio.Bootstrapper")]
namespace Investfolio.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddErrorHandling();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication webApp)
        {
            webApp.UseErrorHandling();
            webApp.UseRouting();
            webApp.MapControllers();

            return webApp;
        }
    }
}
