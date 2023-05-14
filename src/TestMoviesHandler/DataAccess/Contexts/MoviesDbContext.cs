using Microsoft.EntityFrameworkCore;
using Mvs.Domain.Entities;

namespace Mvs.Data.Access.EF.Contexts;

public class MoviesDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }

    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) 
        : base(options)
    {

    }
}