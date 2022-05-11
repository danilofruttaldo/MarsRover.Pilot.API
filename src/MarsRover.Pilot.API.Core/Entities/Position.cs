using MarsRover.Pilot.API.Core.Entities.Base;

namespace MarsRover.Pilot.API.Core.Entities
{
    public class Position : EntityBase
    {
        public long X { get; set; }
        public long Y { get; set; }
        public char Direction { get; set; }
    }
}