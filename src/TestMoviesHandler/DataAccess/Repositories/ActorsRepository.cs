using Mvs.Data.Access.EF.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities;

namespace Mvs.Data.Access.EF.Repositories;

public class ActorsRepository : GenericRepository<Actor>, IActorsRepository
{
    public ActorsRepository(MoviesDbContext context) : base(context)
    {
    }
}