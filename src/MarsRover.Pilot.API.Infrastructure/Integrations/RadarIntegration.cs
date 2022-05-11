using MarsRover.Pilot.API.Core.Integrations;

namespace MarsRover.Pilot.API.Infrastructure.Integrations
{
    public class RadarIntegration : IRadarIntegration
    {
        public RadarIntegration()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool HasObstacleAhead(char direction)
        {
            return new Random().Next(2) == 1;
        }
    }
}
