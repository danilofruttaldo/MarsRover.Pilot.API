using MarsRover.Pilot.API.Application.DTOs;
using MarsRover.Pilot.API.Application.Interfaces;
using MarsRover.Pilot.API.Application.Mapper;
using MarsRover.Pilot.API.Core.Entities;
using MarsRover.Pilot.API.Core.Integrations.Manager;
using MarsRover.Pilot.API.Core.Repositories.Manager;

namespace MarsRover.Pilot.API.Application.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IIntegrationManager _integrationManager;

        public PositionService(IRepositoryManager repositoryManager, IIntegrationManager integrationManager)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _integrationManager = integrationManager ?? throw new ArgumentNullException(nameof(integrationManager));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PositionDto GetCurrentPosition()
        {
            Position entity = _integrationManager.PositionIntegration.GetCurrentPosition();
            PositionDto dto = ObjectMapper.Mapper.Map<PositionDto>(entity);

            return dto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task SaveCurrentPositionAsync(PositionDto position)
        {
            IEnumerable<Position> existingPosition = await _repositoryManager.PositionRepository.GetAsync(p => p.X == position.X && p.Y == position.Y && p.Direction == position.Direction);
            if (!existingPosition.Any())
            {
                Position entity = ObjectMapper.Mapper.Map<Position>(position);
                await _repositoryManager.PositionRepository.InsertAsync(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task<bool> HasKnownObstacleAheadAsync(PositionDto position)
        {
            IEnumerable<Position> existingPosition = await _repositoryManager.PositionRepository.GetAsync(p => p.X == position.X && p.Y == position.Y && p.Direction == position.Direction);

            return existingPosition.Any();
        }
    }
}