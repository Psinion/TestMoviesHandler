using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Data.Repositories.Base;
using TestMoviesHandler.Dtos;

namespace TestMoviesHandler.Data.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(MoviesDbContext context) : base(context)
    {
    }

    public User? GetByUserName(string userName) => dbSet.FirstOrDefault(x => x.UserName == userName);

    public User? Authenticate(UserAuthRequestDto userAuthRequest)
    {
        var user = GetByUserName(userAuthRequest.UserName);

        return user;
    }
}