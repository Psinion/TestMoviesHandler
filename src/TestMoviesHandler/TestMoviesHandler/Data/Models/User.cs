using System.ComponentModel.DataAnnotations.Schema;
using TestMoviesHandler.Data.Models.Base;

namespace TestMoviesHandler.Data.Models;

public class User : Entity
{
    [Column(TypeName = "nvarchar(50)")]
    public string UserName { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Password { get; set; }
}