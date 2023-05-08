using Mvs.Domain.Entities;

namespace Mvs.Data.Repositories.Base;

public interface IMoviesRepository : IRepository<Movie>
{ 
    Task<List<Movie>> GetAllWithActorsAsync();

    Task<Movie> GetByIdWithActorsAsync(int id);
}