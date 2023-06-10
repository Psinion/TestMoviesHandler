using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mvs.Data.OperationResults;
using Mvs.Data.Services;
using Mvs.Data.Services.Tokens;
using Mvs.Domain.Entities;

namespace Mvs.Logic.Services;

public class TokenService : ITokenService
{
    private const int AccessTokenExpireMinutes = 30;
    private const int LongRefreshTokenExpireMinutes = 108000;
    private const int ShortRefreshTokenExpireMinutes = 540;

    private readonly string _jwtSecretKey;

    public TokenService(IConfiguration configuration)
    {
        _jwtSecretKey = configuration["SecretJwt"] ?? throw new NullReferenceException();
    }

    public Result<(string accessToken, string refreshToken)> GenerateTokens(TokenInfo tokenInfo, bool isRememberMe = true)
    {
        var accessToken = GenerateToken(tokenInfo, AccessTokenExpireMinutes);
        var refreshToken = GenerateToken(
            tokenInfo,
            isRememberMe ? LongRefreshTokenExpireMinutes : ShortRefreshTokenExpireMinutes
        );

        // TODO: Добавить сохранение рефреш токена в бд.

        return (accessToken, refreshToken);
    }

    private string GenerateToken(TokenInfo tokenInfo, int expireMinutes = 20)
    {
        var symmetricKey = Encoding.ASCII.GetBytes(_jwtSecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var now = DateTime.UtcNow;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(nameof(User.Id), tokenInfo.Id.ToString()),
                new Claim(nameof(User.Username), tokenInfo.Username),
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