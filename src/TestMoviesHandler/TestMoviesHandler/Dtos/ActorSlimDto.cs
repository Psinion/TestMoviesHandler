using TestMoviesHandler.Dtos.Base;

namespace TestMoviesHandler.Dtos;

/// <summary>
/// Not hierarchical dto
/// </summary>
public class ActorSlimDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}