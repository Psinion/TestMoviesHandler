using Microsoft.EntityFrameworkCore;
using TestMoviesHandler.Data.Models;

namespace TestMoviesHandler.Data;

public class MoviesDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }

    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) 
        : base(options)
    {

    }
}