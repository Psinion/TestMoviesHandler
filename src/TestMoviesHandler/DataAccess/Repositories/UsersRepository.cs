using Microsoft.EntityFrameworkCore;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.DTOs;
using Mvs.Domain.Entities;

namespace Mvs.Data.Access.EF.Repositories;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(MoviesDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUserName(string userName) => await dbSet.FirstOrDefaultAsync(x => x.UserName == userName);

    public async Task<User?> Authenticate(UserAuthRequestDto userAuthRequest)
    {
        var user = await GetByUserName(userAuthRequest.UserName);
        return user;
    }
}