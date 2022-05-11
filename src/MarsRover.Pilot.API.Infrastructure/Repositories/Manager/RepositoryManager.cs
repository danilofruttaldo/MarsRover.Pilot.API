using MarsRover.Pilot.API.Core.Repositories;
using MarsRover.Pilot.API.Core.Repositories.Manager;
using MarsRover.Pilot.API.Infrastructure.Context;
using System.Reflection;

namespace MarsRover.Pilot.API.Infrastructure.Repositories.Manager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RoverContext _context;

        public IPositionRepository PositionRepository { get; private set; }

        public RepositoryManager(RoverContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            PositionRepository = new PositionRepository(_context);
        }

        public TRepository GetRepository<TRepository>()
        {
            PropertyInfo? property = GetType().GetProperty(typeof(TRepository).Name);
            if (property == null)
                throw new ArgumentNullException(nameof(TRepository));

            object? result = property.GetValue(this, null);
            if (result is TRepository repository)
                return repository;

            try
            {
                return (TRepository)Convert.ChangeType(result, typeof(TRepository));
            }
            catch (InvalidCastException)
            {
                return default;
            }
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync()
                             .ConfigureAwait(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }

            disposed = true;
        }
    }
}