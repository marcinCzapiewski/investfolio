using Humanizer;
using Investoflio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Investfolio.Shared.Infrastructure.Exceptions
{
    internal class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private static readonly ConcurrentDictionary<Type, string> _codes = new();

        public ExceptionResponse Map(Exception response)
            => response switch
            {
                InvestfolioException ex => new ExceptionResponse(GetErrorCode(ex), HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new ErrorsResponse(new Error("error", "There has been an error")), HttpStatusCode.InternalServerError)
            };

        private record Error(string Code, string Message);
        private record ErrorsResponse(params Error[] Errors);

        private static string GetErrorCode(object ex)
        { 
            var type = ex.GetType();

            return _codes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
        }
    }
}
