using Microsoft.EntityFrameworkCore;
using Mvs.Data.Access.EF.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities.Base;

namespace Mvs.Data.Access.EF.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MoviesDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public GenericRepository(MoviesDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await DbSet.ToListAsync(cancellationToken);

    public virtual async Task<TEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default) 
        => await DbSet.FindAsync(id, cancellationToken);

    public virtual async Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        await Context.AddAsync(item, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);

        return item;
    }

    public virtual async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        Context.Update(item);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        Context.Remove(new TEntity { Id = id });
        await Context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}