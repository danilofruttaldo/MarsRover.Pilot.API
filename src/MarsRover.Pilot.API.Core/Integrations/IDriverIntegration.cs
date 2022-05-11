namespace MarsRover.Pilot.API.Core.Integrations
{
    public interface IDriverIntegration
    {
        void MoveTo(char direction);
    }
}