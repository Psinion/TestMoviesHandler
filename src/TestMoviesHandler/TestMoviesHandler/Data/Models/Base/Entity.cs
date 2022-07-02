using System.ComponentModel.DataAnnotations;

namespace TestMoviesHandler.Data.Models.Base;

public class Entity
{
    [Key]
    public int Id { get; set; }
}