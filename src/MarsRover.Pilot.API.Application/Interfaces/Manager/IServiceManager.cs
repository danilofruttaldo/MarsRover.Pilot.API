namespace MarsRover.Pilot.API.Application.Interfaces.Manager
{
    public interface IServiceManager
    {
        IDriverService DriverService { get; }
        IPositionService PositionService { get; }

        TService GetService<TService>();
    }
}