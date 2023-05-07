using TestMoviesHandler.Dtos;

namespace TestMoviesHandler.Data.Services.Base;

public interface IUsersService
{
    UserAuthResponseDto? Authenticate(UserAuthRequestDto request);
}