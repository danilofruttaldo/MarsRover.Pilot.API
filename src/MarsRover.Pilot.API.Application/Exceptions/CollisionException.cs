using MarsRover.Pilot.API.Application.DTOs;

namespace MarsRover.Pilot.API.Application.Exceptions
{
    public class CollisionException : Exception
    {
        public PositionDto Position { get; set; }

        public CollisionException(string message, PositionDto position)
            : base(message)
        {
            Position = position;
        }
    }
}