using Investfolio.Modules.Quotes.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Investfolio.Bootstrapper")]
namespace Investfolio.Modules.Quotes.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddQuotes(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }
    }
}
