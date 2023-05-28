using Mvs.Domain.Entities;

namespace Mvs.Data.Services;

public interface ICredentialsService
{
    public string UserName { get; }
    public User CurrentUser { get; }
}