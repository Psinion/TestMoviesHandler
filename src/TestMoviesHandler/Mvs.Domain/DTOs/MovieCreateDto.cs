using Mvs.Domain.DTOs.Base;
using Mvs.Domain.Entities.Enums;

namespace Mvs.Domain.DTOs;

/// <summary>
/// Data Transfer Object for movie creation.
/// </summary>
public class MovieCreateDto : IDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public GenreType Genre { get; set; }

    public IList<int> ActorsId { get; set; }
}