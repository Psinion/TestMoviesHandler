using Mvs.Domain.Entities.Base;

namespace Mvs.Data.Repositories;

public interface IGenericRepository<TEntity> : IDisposable
    where TEntity : IEntity
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}