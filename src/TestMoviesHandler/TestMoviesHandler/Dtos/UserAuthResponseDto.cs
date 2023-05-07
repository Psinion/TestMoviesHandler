using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Dtos.Base;

namespace TestMoviesHandler.Dtos;

public class UserAuthResponseDto : IDto
{
    public User User { get; set; }
    public string Token { get; set; }
}