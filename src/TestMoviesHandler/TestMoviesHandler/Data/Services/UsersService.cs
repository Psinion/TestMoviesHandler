using TestMoviesHandler.Data.Repositories.Base;
using TestMoviesHandler.Data.Services.Base;
using TestMoviesHandler.Dtos;

namespace TestMoviesHandler.Data.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public UserAuthResponseDto? Authenticate(UserAuthRequestDto request)
    {
        var user = _usersRepository.Authenticate(request);

        if (user == null)
        {
            return null;
        }

        var response = new UserAuthResponseDto()
        {
            User = user,
            Token = "GugaBuga"
        };

        return response;
    }
}