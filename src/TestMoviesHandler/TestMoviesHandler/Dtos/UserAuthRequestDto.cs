using TestMoviesHandler.Dtos.Base;

namespace TestMoviesHandler.Dtos;

public class UserAuthRequestDto : IDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}