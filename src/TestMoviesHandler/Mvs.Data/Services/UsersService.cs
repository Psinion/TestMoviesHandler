using Mvs.Data.Repositories.Base;
using Mvs.Data.Services.Base;
using Mvs.Domain.DTOs;

namespace Mvs.Data.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserAuthResponseDto?> Authenticate(UserAuthRequestDto request)
    {
        var user = await _usersRepository.Authenticate(request);

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