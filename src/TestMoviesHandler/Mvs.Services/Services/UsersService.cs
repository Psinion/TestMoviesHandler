using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Domain.DTOs;

namespace Mvs.Logic.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository;
    }

    public async Task<UserAuthResponseDto?> Authenticate(UserAuthRequestDto request)
    {
        var user = await usersRepository.Authenticate(request);

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