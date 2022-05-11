using MarsRover.Pilot.API.Application.DTOs;

namespace MarsRover.Pilot.API.Application.Interfaces
{
    public interface IDriverService
    {
        Task MoveToAsync(CommandDto command);
    }
}