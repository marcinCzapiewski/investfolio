namespace Investoflio.Shared.Abstractions.Exceptions
{
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception response);
    }
}
