using System.ComponentModel.DataAnnotations.Schema;
using TestMoviesHandler.Models.Base;

namespace TestMoviesHandler.Models;

public class Actor : Entity
{
    public string Name { get; set; }

    public string Surname { get; set; }
}