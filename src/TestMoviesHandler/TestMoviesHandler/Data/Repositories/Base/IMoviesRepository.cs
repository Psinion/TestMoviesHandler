using TestMoviesHandler.Data.Models;

namespace TestMoviesHandler.Data.Repositories.Base;

public interface IMoviesRepository : IRepository<Movie>
{ 
    Task<List<Movie>> GetAllWithActorsAsync();

    Task<Movie> GetByIdWithActorsAsync(int id);
}