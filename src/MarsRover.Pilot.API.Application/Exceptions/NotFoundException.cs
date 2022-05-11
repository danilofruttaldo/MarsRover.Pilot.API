namespace MarsRover.Pilot.API.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id)
            : base($"The entity with the identifier {id} was not found.")
        {
        }

        public NotFoundException(string id)
            : base($"The entity with the identifier {id} was not found.")
        {
        }
    }
}