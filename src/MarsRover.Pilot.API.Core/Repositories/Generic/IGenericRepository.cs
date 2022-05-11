using System.Linq.Expressions;

namespace MarsRover.Pilot.API.Core.Repositories.Generic
{
    public interface IGenericRepository<TEntity>
            where TEntity : class
    {
        IQueryable<TEntity> GetQueryable();
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter,
                                            CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(int id,
                                   CancellationToken cancellationToken = default);
        Task InsertAsync(TEntity entity,
                         CancellationToken cancellationToken = default);
        Task InsertAsync(IEnumerable<TEntity> entities,
                         CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
    }
}