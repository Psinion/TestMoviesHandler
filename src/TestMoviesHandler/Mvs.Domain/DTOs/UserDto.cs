using Mvs.Domain.DTOs.Base;

namespace Mvs.Domain.DTOs;

public class UserDto : IDto
{
    public string Username { get; set; } = "";
}