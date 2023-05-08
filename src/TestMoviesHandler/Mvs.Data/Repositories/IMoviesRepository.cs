using Mvs.Domain.Entities;

namespace Mvs.Data.Repositories;

public interface IMoviesRepository : IGenericRepository<Movie>
{ 
    Task<List<Movie>> GetAllWithActorsAsync();

    Task<Movie> GetByIdWithActorsAsync(int id);
}