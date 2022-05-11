namespace MarsRover.Pilot.API.Core.Entities.Base
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
