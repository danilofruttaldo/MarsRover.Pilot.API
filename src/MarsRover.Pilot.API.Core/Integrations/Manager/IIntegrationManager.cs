namespace MarsRover.Pilot.API.Core.Integrations.Manager
{
    public interface IIntegrationManager
    {
        public IDriverIntegration DriverIntegration { get; }
        public IPositionIntegration PositionIntegration { get; }
        public IRadarIntegration RadarIntegration { get; }
    }
}