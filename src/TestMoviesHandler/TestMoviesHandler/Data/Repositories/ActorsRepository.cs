using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Data.Repositories.Base;

namespace TestMoviesHandler.Data.Repositories;

public class ActorsRepository : Repository<Actor>, IActorsRepository
{
    public ActorsRepository(MoviesDbContext context) : base(context)
    {
    }
}