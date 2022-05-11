﻿namespace MarsRover.Pilot.API.Core.Entities.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
