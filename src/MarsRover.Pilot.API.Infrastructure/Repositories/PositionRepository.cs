using MarsRover.Pilot.API.Core.Entities;
using MarsRover.Pilot.API.Core.Repositories;
using MarsRover.Pilot.API.Infrastructure.Context;
using MarsRover.Pilot.API.Infrastructure.Repositories.Generic;

namespace MarsRover.Pilot.API.Infrastructure.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(RoverContext dbContext) : base(dbContext) { }
    }
}
