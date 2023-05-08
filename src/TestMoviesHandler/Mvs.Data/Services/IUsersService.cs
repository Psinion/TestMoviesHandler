using Mvs.Domain.DTOs;

namespace Mvs.Data.Services;

public interface IUsersService
{
    Task<UserAuthResponseDto?> Authenticate(UserAuthRequestDto request);
}