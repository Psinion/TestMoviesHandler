using Mvs.Domain.DTOs;
using Mvs.Domain.Entities;

namespace Mvs.Data.Repositories;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<User?> GetByUsername(string userName);

    Task<User?> Authenticate(UserAuthRequestDto userAuthRequest);
}