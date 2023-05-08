using System.ComponentModel.DataAnnotations;

namespace Mvs.Domain.Entities.Base;

public class Entity : IEntity
{
    [Key]
    public int Id { get; set; }
}