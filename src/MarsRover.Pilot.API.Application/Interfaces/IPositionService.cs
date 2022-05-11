using MarsRover.Pilot.API.Application.DTOs;

namespace MarsRover.Pilot.API.Application.Interfaces
{
    public interface IPositionService
    {
        PositionDto GetCurrentPosition();
        Task SaveCurrentPositionAsync(PositionDto position);

        Task<bool> HasKnownObstacleAheadAsync(PositionDto position);
    }
}