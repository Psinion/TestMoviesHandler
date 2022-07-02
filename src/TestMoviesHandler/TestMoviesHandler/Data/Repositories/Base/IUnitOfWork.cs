using Microsoft.EntityFrameworkCore;

namespace TestMoviesHandler.Data.Repositories.Base;

public interface IUnitOfWork : IDisposable
{
    IMoviesRepository MoviesRepository { get; }
    IActorsRepository ActorsRepository { get; }

    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();

    void OpenSession();

    void CloseSession();
}