using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Dtos;

namespace TestMoviesHandler.Data.Repositories.Base;

public interface IUsersRepository : IRepository<User>
{
    User? GetByUserName(string userName);

    User? Authenticate(UserAuthRequestDto userAuthRequest);
}