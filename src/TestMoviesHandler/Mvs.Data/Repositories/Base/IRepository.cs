using Mvs.Domain.Entities.Base;

namespace Mvs.Data.Repositories.Base;

public interface IRepository<TEntity> : IDisposable
    where TEntity : IEntity
{
    Task<TEntity?> GetByIdAsync(int id);

    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> CreateAsync(TEntity item);

    Task UpdateAsync(TEntity item);

    Task DeleteAsync(int id);
}