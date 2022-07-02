using System.ComponentModel.DataAnnotations.Schema;
using TestMoviesHandler.Models.Base;

namespace TestMoviesHandler.Models;

public class Actor : Entity
{
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Surname { get; set; }
}