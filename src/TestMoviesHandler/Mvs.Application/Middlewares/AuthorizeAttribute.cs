using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mvs.Application.Middlewares;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userName = (string?)context.HttpContext.Items["UserName"];
        if (userName == null)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}