using Investoflio.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Investfolio.Shared.Infrastructure.Exceptions
{
    internal class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly IExceptionToResponseMapper _exceptionToResponseMapper;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(
            IExceptionToResponseMapper exceptionToResponseMapper,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _exceptionToResponseMapper = exceptionToResponseMapper;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleErrorAsync(context, ex);
            }
        }

        private Task HandleErrorAsync(HttpContext httpContext, Exception ex)
        {
            var errorResponse = _exceptionToResponseMapper.Map(ex);
            httpContext.Response.StatusCode = (int) (errorResponse?.StatusCode ?? HttpStatusCode.InternalServerError);

            if (errorResponse?.Response is null)
            {
                return Task.CompletedTask;
            }

            return httpContext.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
