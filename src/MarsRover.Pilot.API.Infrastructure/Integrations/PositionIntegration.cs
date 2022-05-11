using MarsRover.Pilot.API.Core.Entities;
using MarsRover.Pilot.API.Core.Integrations;

namespace MarsRover.Pilot.API.Infrastructure.Integrations
{
    public class PositionIntegration : IPositionIntegration
    {
        public PositionIntegration()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Position GetCurrentPosition()
        {
            Random random = new();
            string directions = "NSEW";

            return new Position()
            {
                X = random.Next(),
                Y = random.Next(),
                Direction = directions[random.Next(0, directions.Length)],
            };
        }
    }
}