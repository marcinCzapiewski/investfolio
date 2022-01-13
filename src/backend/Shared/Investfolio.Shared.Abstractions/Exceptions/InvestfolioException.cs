namespace Investoflio.Shared.Abstractions.Exceptions
{
    public abstract class InvestfolioException : Exception
    {
        protected InvestfolioException(string message) : base(message)
        {
        }
    }
}
