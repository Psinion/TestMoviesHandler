using Mvs.Domain.DTOs.Base;

namespace Mvs.Domain.DTOs;

public class UserPermissionsResponseDto : IDto
{
    public List<string> Permissions { get; set; }
}