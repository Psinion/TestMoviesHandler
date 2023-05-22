using Mvs.Data.OperationResults;
using Mvs.Data.Services.Tokens;

namespace Mvs.Data.Services;

public interface ITokenService
{
    /// <summary>
    /// Создать access token на короткое время (15 минут) и refreshToken на длительное (месяц).
    /// </summary>
    /// <param name="tokenInfo">Данные, которые будут записаны в токен.</param>
    /// <param name="isRememberMe">Нужно ли создавать токен дольше нескольких часов.</param>
    /// <returns></returns>
    Result<(string accessToken, string refreshToken)> GenerateTokens(TokenInfo tokenInfo, bool isRememberMe = true);
}