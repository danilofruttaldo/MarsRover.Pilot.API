namespace MarsRover.Pilot.API.Core.Interfaces
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogException(string message, params object[] args);
    }
}