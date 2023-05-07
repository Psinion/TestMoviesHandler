using TestMoviesHandler.Dtos.Base;
using TestMoviesHandler.Models.Enums;

namespace TestMoviesHandler.Dtos;

public class MovieSlimDto : IDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public GenreType Genre { get; set; }

    public IList<ActorSlimDto> Actors { get; set; }
}