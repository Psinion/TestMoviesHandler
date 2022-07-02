using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Data.Repositories.Base;

namespace TestMoviesHandler.Data.Repositories;

public class MoviesRepository : Repository<Movie>, IMoviesRepository
{
    public MoviesRepository(MoviesDbContext context) : base(context)
    {

    }
}