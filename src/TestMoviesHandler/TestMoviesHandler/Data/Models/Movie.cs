using System.ComponentModel.DataAnnotations.Schema;
using TestMoviesHandler.Data.Models.Base;
using TestMoviesHandler.Models.Enums;

namespace TestMoviesHandler.Data.Models;

public class Movie : Entity
{
    [Column(TypeName = "nvarchar(50)")]
    public string Title { get; set; }

    public GenreType Genre { get; set; }

    public IList<Actor> Actors { get; set; }
}