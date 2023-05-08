using Mvs.Data.Contexts;
using Mvs.Data.Repositories.Base;
using Mvs.Domain.Entities;

namespace Mvs.Data.Repositories;

public class ActorsRepository : Repository<Actor>, IActorsRepository
{
    public ActorsRepository(MoviesDbContext context) : base(context)
    {
    }
}