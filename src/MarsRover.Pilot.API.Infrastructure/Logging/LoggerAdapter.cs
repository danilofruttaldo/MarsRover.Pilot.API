using MarsRover.Pilot.API.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace MarsRover.Pilot.API.Infrastructure.Logging
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger<T>();

        public void LogWarning(string message, params object[] args) => _logger.LogWarning(message, args);

        public void LogInformation(string message, params object[] args) => _logger.LogInformation(message, args);

        public void LogError(string message, params object[] args) => _logger.LogError(message, args);

        public void LogException(string message, params object[] args) => _logger.LogCritical(message, args);
    }
}
