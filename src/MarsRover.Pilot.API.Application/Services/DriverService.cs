using MarsRover.Pilot.API.Application.DTOs;
using MarsRover.Pilot.API.Application.Exceptions;
using MarsRover.Pilot.API.Application.Interfaces;
using MarsRover.Pilot.API.Application.Mapper;
using MarsRover.Pilot.API.Core.Entities;
using MarsRover.Pilot.API.Core.Integrations.Manager;
using MarsRover.Pilot.API.Core.Repositories.Manager;

namespace MarsRover.Pilot.API.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IIntegrationManager _integrationManager;

        public DriverService(IRepositoryManager repositoryManager, IIntegrationManager integrationManager)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _integrationManager = integrationManager ?? throw new ArgumentNullException(nameof(integrationManager));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public async Task MoveToAsync(CommandDto command)
        {
            foreach (char direction in command.Commands)
            {
                Position currentPosition = _integrationManager.PositionIntegration.GetCurrentPosition();

                if (await HasKnownObstacleAheadAsync(currentPosition, direction) || _integrationManager.RadarIntegration.HasObstacleAhead(direction))
                {
                    currentPosition.Direction = direction;
                    throw new CollisionException("Obstacle found: sequence aborted", ObjectMapper.Mapper.Map<PositionDto>(currentPosition));
                }

                _integrationManager.DriverIntegration.MoveTo(direction);
            }

            async Task<bool> HasKnownObstacleAheadAsync(Position currentPosition, char direction)
                => (await _repositoryManager.PositionRepository.GetAsync(p => p.Direction == direction && p.X == currentPosition.X && p.Y == currentPosition.Y)) == null;
        }
    }
}