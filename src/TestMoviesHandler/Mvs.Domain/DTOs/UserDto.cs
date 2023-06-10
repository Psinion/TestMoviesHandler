using Mvs.Domain.DTOs.Base;

namespace Mvs.Domain.DTOs;

public class UserDto : IDto
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
}