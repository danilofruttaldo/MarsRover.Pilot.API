using MarsRover.Pilot.API.Core.Repositories.Generic;
using MarsRover.Pilot.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarsRover.Pilot.API.Infrastructure.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        protected readonly RoverContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(RoverContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetQueryable()
            => _dbSet;

        public virtual async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken)
                           .ConfigureAwait(false);
        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter,
                                                                 CancellationToken cancellationToken = default)
            => await _dbSet.Where(filter)
                           .ToListAsync(cancellationToken)
                           .ConfigureAwait(false);

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(new object[] { id }, cancellationToken)
                           .ConfigureAwait(false);

        public virtual async Task InsertAsync(TEntity entity,
                                              CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken)
                           .ConfigureAwait(false);
        public virtual async Task InsertAsync(IEnumerable<TEntity> entities,
                                              CancellationToken cancellationToken = default)
            => await _dbSet.AddRangeAsync(entities, cancellationToken)
                           .ConfigureAwait(false);

        public virtual void Update(TEntity entity)
            => _context.Entry(entity).State = EntityState.Modified;
        public virtual void Update(IEnumerable<TEntity> entities)
            => entities.ToList()
                       .ForEach(e => Update(e));

        public virtual void Remove(TEntity entity)
            => _dbSet.Remove(entity);
        public virtual void Remove(IEnumerable<TEntity> entities)
            => _dbSet.RemoveRange(entities);

    }
}