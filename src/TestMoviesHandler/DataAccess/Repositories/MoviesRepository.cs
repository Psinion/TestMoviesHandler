using Microsoft.EntityFrameworkCore;
using Mvs.Data.Access.EF.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities;

namespace Mvs.Data.Access.EF.Repositories;

public class MoviesRepository : GenericRepository<Movie>, IMoviesRepository
{
    public MoviesRepository(MoviesDbContext context) : base(context)
    {

    }

    public virtual async Task<List<Movie>> GetAllWithActorsAsync() => await DbSet.Include(x => x.Actors).ToListAsync();

    public async Task<Movie?> GetByIdWithActorsAsync(int id)
    {
        return await DbSet
            .Include(x => x.Actors)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}