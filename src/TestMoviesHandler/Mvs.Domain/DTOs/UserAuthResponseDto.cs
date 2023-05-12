using Mvs.Domain.DTOs.Base;
using Mvs.Domain.Entities;

namespace Mvs.Domain.DTOs;

public class UserAuthResponseDto : IDto
{
    public UserDto? User { get; set; }
    public string Token { get; set; } = "";
}