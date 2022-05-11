namespace MarsRover.Pilot.API.Core.Integrations
{
    public interface IRadarIntegration
    {
        bool HasObstacleAhead(char direction);
    }
}