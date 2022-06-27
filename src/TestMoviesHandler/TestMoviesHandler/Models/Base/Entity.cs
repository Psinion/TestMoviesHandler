using System.ComponentModel.DataAnnotations;

namespace TestMoviesHandler.Models.Base;

public class Entity
{
    [Key]
    public int Id { get; set; }
}