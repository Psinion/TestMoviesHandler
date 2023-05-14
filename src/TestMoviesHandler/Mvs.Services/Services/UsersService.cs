using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mvs.Data.Repositories;
using Mvs.Data.Services;
using Mvs.Domain.DTOs;
using Mvs.Domain.Entities;

namespace Mvs.Logic.Services;

public class UsersService : IUsersService
{
    private const int shortExpireMinutes = 1440;
    private const int longExpireMinutes = 43200;

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
            User = new UserDto()
            {
                Username = user.Username
            },
            Token = GenerateToken(user.Username, request.RememberMe ? longExpireMinutes : shortExpireMinutes)
        };

        return response;
    }

    public string GenerateToken(string username, int expireMinutes = 20)
    {
        var hmac = new HMACSHA256();
        var kek = Convert.ToBase64String(hmac.Key);

        var symmetricKey = Encoding.ASCII.GetBytes(_jwtSecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var now = DateTime.UtcNow;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(nameof(User.Username), username)
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