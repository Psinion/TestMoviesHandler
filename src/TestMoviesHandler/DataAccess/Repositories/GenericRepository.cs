using Microsoft.EntityFrameworkCore;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities.Base;

namespace Mvs.Data.Access.EF.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MoviesDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(MoviesDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await _dbSet.ToListAsync(cancellationToken);

    public virtual async Task<TEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default) 
        => await _dbSet.FindAsync(id, cancellationToken);

    public virtual async Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        await _context.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return item;
    }

    public virtual async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _context.Update(item);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        _context.Remove(new TEntity { Id = id });
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}