using Microsoft.EntityFrameworkCore;
using Mvs.Data.Access.EF.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.DTOs;
using Mvs.Domain.Entities;

namespace Mvs.Data.Access.EF.Repositories;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(MoviesDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsername(string userName) => await _dbSet.FirstOrDefaultAsync(x => x.Username == userName);

    public async Task<User?> Authenticate(UserAuthRequestDto userAuthRequest)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => 
            x.Username == userAuthRequest.UserName &&
            x.Password == userAuthRequest.Password
        );
        return user;
    }
}