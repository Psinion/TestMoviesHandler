using Mvs.Data.Contexts;
using Mvs.Data.Repositories;

namespace Mvs.Data.Access.EF.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MoviesDbContext context;

    public IMoviesRepository MoviesRepository { get; }
    public IActorsRepository ActorsRepository { get; }

    public UnitOfWork(MoviesDbContext context)
    {
        this.context = context;

        MoviesRepository = new MoviesRepository(context);
        ActorsRepository = new ActorsRepository(context);
    }

    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public void CommitTransaction()
    {
        context.SaveChanges();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    public void OpenSession()
    {
        throw new NotImplementedException();
    }

    public void CloseSession()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}