using System.ComponentModel.DataAnnotations.Schema;
using Mvs.Domain.Entities.Base;

namespace Mvs.Domain.Entities;

public class User : Entity
{
    [Column(TypeName = "varchar(50)")]
    public string Username { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Password { get; set; }
}