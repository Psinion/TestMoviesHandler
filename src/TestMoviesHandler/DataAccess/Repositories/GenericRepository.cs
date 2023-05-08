using Microsoft.EntityFrameworkCore;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities.Base;

namespace Mvs.Data.Access.EF.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MoviesDbContext context;
    protected readonly DbSet<TEntity> dbSet;

    public GenericRepository(MoviesDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await dbSet.ToListAsync(cancellationToken);

    public virtual async Task<TEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default) 
        => await dbSet.FindAsync(id, cancellationToken);

    public virtual async Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        await context.AddAsync(item, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return item;
    }

    public virtual async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        context.Update(item);
        await context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        context.Remove(new TEntity { Id = id });
        await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        context.Dispose();
    }
}