using Mvs.Domain.DTOs.Base;

namespace Mvs.Domain.DTOs;

public class UserAuthRequestDto : IDto
{
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";
    public bool RememberMe { get; set; }
}