using Microsoft.EntityFrameworkCore;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories.Base;
using Mvs.Domain.Entities;

namespace Mvs.Data.Repositories;

public class MoviesRepository : Repository<Movie>, IMoviesRepository
{
    public MoviesRepository(MoviesDbContext context) : base(context)
    {

    }

    public virtual async Task<List<Movie>> GetAllWithActorsAsync() => await dbSet.Include(x => x.Actors).ToListAsync();

    public async Task<Movie> GetByIdWithActorsAsync(int id)
    {
        return await dbSet
            .Include(x => x.Actors)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}