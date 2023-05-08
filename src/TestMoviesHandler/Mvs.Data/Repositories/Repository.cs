using Microsoft.EntityFrameworkCore;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories.Base;
using Mvs.Domain.Entities.Base;

namespace Mvs.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MoviesDbContext context;
    protected readonly DbSet<TEntity> dbSet;

    public Repository(MoviesDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id) => await dbSet.FindAsync(id);

    public virtual async Task<List<TEntity>> GetAllAsync() => await dbSet.ToListAsync();

    public virtual async Task<TEntity> CreateAsync(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await context.AddAsync(item);
        await context.SaveChangesAsync();

        return item;
    }

    public virtual async Task UpdateAsync(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        context.Update(item);
        await context.SaveChangesAsync();
    }
    public virtual async Task DeleteAsync(int id)
    {
        context.Remove(new TEntity { Id = id });
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}