namespace MarsRover.Pilot.API.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(string message)
               : base(message)
        {
        }

        internal InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}