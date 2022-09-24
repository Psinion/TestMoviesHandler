using TestMoviesHandler.Models.Base;

namespace TestMoviesHandler.Models;

/// <summary>
/// Not hierarchical dto
/// </summary>
public class ActorSlimDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}