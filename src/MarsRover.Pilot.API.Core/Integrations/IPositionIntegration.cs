using MarsRover.Pilot.API.Core.Entities;

namespace MarsRover.Pilot.API.Core.Integrations
{
    public interface IPositionIntegration
    {
        Position GetCurrentPosition();
    }
}