using Microsoft.AspNetCore.Http;
using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Domain.Entities;

namespace Mvs.Logic.Services;

public class CredentialsService : ICredentialsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUsersRepository _usersRepository;

    public string UserName { get; }

    private User? _currentUser;
    public User CurrentUser => _currentUser ??= _usersRepository.GetByUsername(UserName).Result 
                                                ?? throw new NullReferenceException("User not found");

    public CredentialsService(IHttpContextAccessor httpContextAccessor, IUsersRepository usersRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _usersRepository = usersRepository;

        UserName = (string?)httpContextAccessor.HttpContext?.Items["UserName"] ?? "";
    }
}