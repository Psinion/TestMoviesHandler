using Mvs.Domain.DTOs.Base;

namespace Mvs.Domain.DTOs;

/// <summary>
/// Not hierarchical dto
/// </summary>
public class ActorSlimDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}