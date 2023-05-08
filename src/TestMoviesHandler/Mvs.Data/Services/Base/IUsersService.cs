using Mvs.Domain.DTOs;

namespace Mvs.Data.Services.Base;

public interface IUsersService
{
    Task<UserAuthResponseDto?> Authenticate(UserAuthRequestDto request);
}