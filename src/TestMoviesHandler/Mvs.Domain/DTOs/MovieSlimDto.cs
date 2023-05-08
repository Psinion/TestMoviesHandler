using Mvs.Domain.DTOs.Base;
using Mvs.Domain.Entities.Enums;

namespace Mvs.Domain.DTOs;

public class MovieSlimDto : IDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public GenreType Genre { get; set; }

    public IList<ActorSlimDto> Actors { get; set; }
}