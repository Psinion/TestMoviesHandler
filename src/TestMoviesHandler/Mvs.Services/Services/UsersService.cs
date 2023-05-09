using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Domain.DTOs;

namespace Mvs.Logic.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly string _jwtSecretKey;

    public UsersService(IConfiguration configuration, IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
        _jwtSecretKey = configuration["SecretJwt"] ?? throw new NullReferenceException();
    }

    public async Task<UserAuthResponseDto?> Authenticate(UserAuthRequestDto request)
    {
        var user = await _usersRepository.Authenticate(request);

        if (user == null)
        {
            return null;
        }

        var response = new UserAuthResponseDto()
        {
            User = user,
            Token = GenerateToken(user.UserName, 600)
        };

        return response;
    }

    public string GenerateToken(string username, int expireMinutes = 20)
    {
        var hmac = new HMACSHA256();
        var kek = Convert.ToBase64String(hmac.Key);

        var symmetricKey = Convert.FromBase64String(_jwtSecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var now = DateTime.UtcNow;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),

            Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(symmetricKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var stoken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(stoken);

        return token;
    }
}