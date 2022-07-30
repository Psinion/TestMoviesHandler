using System.ComponentModel.DataAnnotations.Schema;
using TestMoviesHandler.Data.Models.Base;

namespace TestMoviesHandler.Data.Models;

public class Actor : Entity
{
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Surname { get; set; }

    public IList<Movie> Movies { get; set; } = new List<Movie>();
}