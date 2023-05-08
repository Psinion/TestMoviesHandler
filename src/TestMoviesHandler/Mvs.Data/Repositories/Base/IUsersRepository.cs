using Mvs.Domain.DTOs;
using Mvs.Domain.Entities;

namespace Mvs.Data.Repositories.Base;

public interface IUsersRepository : IRepository<User>
{
    Task<User?> GetByUserName(string userName);

    Task<User?> Authenticate(UserAuthRequestDto userAuthRequest);
}