using System.ComponentModel.DataAnnotations.Schema;
using Mvs.Domain.Entities.Base;
using Mvs.Domain.Entities.Enums;

namespace Mvs.Domain.Entities;

public class Movie : Entity
{
    [Column(TypeName = "nvarchar(50)")]
    public string Title { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string Description { get; set; }

    public GenreType Genre { get; set; }

    public IList<Actor> Actors { get; set; }
}