using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities;

namespace Mvs.Application.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _jwtSecretKey;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _jwtSecretKey = configuration["SecretJwt"] ?? throw new NullReferenceException();
    }

    public async Task Invoke(HttpContext context, IUsersRepository usersRepository)
    {
        var token = context.Request.Headers["AuthToken"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            AttachUserToContext(context, usersRepository, token);
        }

        await _next(context);
    }

    public void AttachUserToContext(HttpContext context, IUsersRepository usersRepository, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userName = jwtToken.Claims.First(x => x.Type == nameof(User.Username)).Value;

            var user = usersRepository.GetByUsername(userName).Result;
            context.Items["User"] = user;
        }
        catch(Exception ex)
        {
                        
        }
    }
}