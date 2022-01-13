using Investoflio.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Investfolio.Shared.Infrastructure.Exceptions
{
    internal static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            services
                .AddScoped<ErrorHandlerMiddleware>()
                .AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();

            return services;
        }

        public static WebApplication UseErrorHandling(this WebApplication webApp)
        {
            webApp.UseMiddleware<ErrorHandlerMiddleware>();

            return webApp;
        }
    }
}
