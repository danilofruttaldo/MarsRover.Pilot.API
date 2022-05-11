using MarsRover.Pilot.API.Core.Integrations;
using MarsRover.Pilot.API.Core.Integrations.Manager;
using System.Reflection;

namespace MarsRover.Pilot.API.Infrastructure.Integrations.Manager
{
    public class IntegrationManager : IIntegrationManager
    {
        public IDriverIntegration DriverIntegration { get; private set; }
        public IPositionIntegration PositionIntegration { get; private set; }
        public IRadarIntegration RadarIntegration { get; private set; }

        public IntegrationManager()
        {
            DriverIntegration = new DriverIntegration();
            PositionIntegration = new PositionIntegration();
            RadarIntegration = new RadarIntegration();
        }

        public TRepository GetRepository<TRepository>()
        {
            PropertyInfo? property = GetType().GetProperty(typeof(TRepository).Name);
            if (property == null)
                throw new ArgumentNullException(nameof(TRepository));

            object? result = property.GetValue(this, null);
            if (result is TRepository repository)
                return repository;

            try
            {
                return (TRepository)Convert.ChangeType(result, typeof(TRepository));
            }
            catch (InvalidCastException)
            {
                return default;
            }
        }
    }
}