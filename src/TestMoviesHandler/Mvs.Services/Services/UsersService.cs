using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Domain.DTOs;

namespace Mvs.Logic.Services;

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
            User = new UserDto()
            {
                Id = user.Id,
                Username = user.Username
            }
        };

        return response;
    }
}