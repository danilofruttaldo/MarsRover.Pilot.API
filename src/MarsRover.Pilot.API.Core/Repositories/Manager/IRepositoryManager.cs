namespace MarsRover.Pilot.API.Core.Repositories.Manager
{
    public interface IRepositoryManager : IDisposable
    {
        IPositionRepository PositionRepository { get; }

        TRepository GetRepository<TRepository>();
        Task<int> SaveChangesAsync();
    }
}