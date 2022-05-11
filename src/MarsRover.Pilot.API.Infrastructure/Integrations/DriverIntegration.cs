using MarsRover.Pilot.API.Core.Integrations;
using MarsRover.Pilot.API.Infrastructure.Exceptions;

namespace MarsRover.Pilot.API.Infrastructure.Integrations
{
    public class DriverIntegration : IDriverIntegration
    {
        public DriverIntegration()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <exception cref="InfrastructureException"></exception>
        public void MoveTo(char direction)
        {
            try
            {
                //
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(ex.Message, ex);
            }
        }
    }
}