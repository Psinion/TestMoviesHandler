using System.ComponentModel.DataAnnotations.Schema;
using Mvs.Domain.Entities.Base;

namespace Mvs.Domain.Entities;

public class User : Entity
{
    [Column(TypeName = "nvarchar(50)")]
    public string UserName { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Password { get; set; }
}