using Microsoft.EntityFrameworkCore;
using TestMoviesHandler.Data.Models.Base;
using TestMoviesHandler.Data.Repositories.Base;

namespace TestMoviesHandler.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    private readonly MoviesDbContext context;
    private readonly DbSet<TEntity> dbSet;

    public Repository(MoviesDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual TEntity? GetById(int id) => dbSet.Find(id);

    public virtual async Task<TEntity?> GetByIdAsync(int id) => await dbSet.FindAsync(id);

    public virtual IEnumerable<TEntity> GetAll() => dbSet.ToList();

    public virtual async Task<List<TEntity>> GetAllAsync() => await dbSet.ToListAsync();

    public virtual TEntity Add(TEntity item)
    {
        if(item is null) throw new ArgumentNullException(nameof(item));

        context.Add(item);
        context.SaveChanges();

        return item;
    }

    public virtual async Task<TEntity> AddAsync(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await context.AddAsync(item);
        await context.SaveChangesAsync();

        return item;
    }

    public virtual void Update(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        context.Update(item);
        context.SaveChanges();
    }

    public virtual async Task UpdateAsync(TEntity item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        context.Update(item);
        await context.SaveChangesAsync();
    }

    public virtual void Remove(int id)
    {
        context.Remove(new TEntity { Id = id });
        context.SaveChanges();
    }

    public virtual async Task RemoveAsync(int id)
    {
        context.Remove(new TEntity { Id = id });
        await context.SaveChangesAsync();
    }
}