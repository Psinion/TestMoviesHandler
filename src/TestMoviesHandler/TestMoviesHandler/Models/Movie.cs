using System.ComponentModel.DataAnnotations.Schema;
using TestMoviesHandler.Models.Base;
using TestMoviesHandler.Models.Enums;

namespace TestMoviesHandler.Models;

public class Movie : Entity
{
    public string Title { get; set; }

    public GenreType Genre { get; set; }

    public IList<Actor> Actors { get; set; }
}