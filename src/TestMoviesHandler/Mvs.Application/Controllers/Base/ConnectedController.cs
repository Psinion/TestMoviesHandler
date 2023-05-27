using Microsoft.AspNetCore.Mvc;
using Mvs.Domain.Entities;

namespace Mvs.Application.Controllers.Base
{
    public class ConnectedController : ControllerBase
    {
        protected User? CurrentUser { get; set; }

        public ConnectedController(IHttpContextAccessor httpContextAccessor)
        {
            CurrentUser = (User?)httpContextAccessor.HttpContext.Items["User"];
        }
    }
}
