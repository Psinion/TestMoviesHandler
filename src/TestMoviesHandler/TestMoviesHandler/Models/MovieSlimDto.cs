using TestMoviesHandler.Models.Base;
using TestMoviesHandler.Models.Enums;

namespace TestMoviesHandler.Models;

public class MovieSlimDto : BaseDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public GenreType Genre { get; set; }

    public IList<ActorSlimDto> Actors { get; set; }
}