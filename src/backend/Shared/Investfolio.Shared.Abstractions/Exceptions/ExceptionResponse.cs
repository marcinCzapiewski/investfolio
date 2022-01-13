using System.Net;

namespace Investoflio.Shared.Abstractions.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
