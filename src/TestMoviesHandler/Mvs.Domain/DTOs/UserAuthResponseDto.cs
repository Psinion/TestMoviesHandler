using Mvs.Domain.DTOs.Base;

namespace Mvs.Domain.DTOs;

public class UserAuthResponseDto : IDto
{
    public UserDto? User { get; set; }
    public string AccessToken { get; set; } = "";
}