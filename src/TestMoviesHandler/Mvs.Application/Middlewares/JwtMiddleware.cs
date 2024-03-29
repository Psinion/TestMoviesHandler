﻿using System.IdentityModel.Tokens.Jwt;
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
        var token = context.Request.Headers["AuthToken"].FirstOrDefault()?.Split(" ").Last() 
                    ?? context.Request.Cookies["RefreshToken"];

        if (token != null)
        {
            AttachUserToContext(context, usersRepository, token);
        }

        await _next(context);
    }

    public bool AttachUserToContext(HttpContext context, IUsersRepository usersRepository, string token)
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

            var userId = jwtToken.Claims.First(x => x.Type == nameof(User.Id)).Value;
            context.Items[nameof(User.Id)] = int.Parse(userId);

            var userName = jwtToken.Claims.First(x => x.Type == nameof(User.Username)).Value;
            context.Items[nameof(User.Username)] = userName;
        }
        catch(Exception ex)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return false;
        }

        return true;
    }
}